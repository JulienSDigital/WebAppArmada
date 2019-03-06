using Armada.Database;
using Armada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Armada.Models;
using Armada.Helper;
using Newtonsoft.Json;

namespace Armada.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private ILogger<MessagesController> _logger;
        private IArmadaRepository _repository;
        private IUrlHelper _urlHelper;
    
        public UsersController(ILogger<MessagesController> logger, IArmadaRepository repository, IUrlHelper urlHelper)
        {
            _logger = logger;
            _repository = repository;
            _urlHelper = urlHelper;
        }

        [HttpGet(Name = nameof(GetUsers))]
        public IActionResult GetUsers([FromQuery]Pagination pagination, bool includeMessage = false)
        {
            //Code manuel sans automapper
            //IEnumerable<Entities.User> listUser = _repository.GetUsers(includeMessage);
            //if (includeMessage)
            //{
            //    List<Models.UserDto> resultat = new List<Models.UserDto>();
            //    foreach (var user in listUser)
            //    {
            //        Models.UserDto userDto = new Models.UserDto();
            //        userDto.Name = user.Name;
            //        userDto.Surname = user.Surname;
            //        userDto.Birthday = user.Birthday;
            //        //...

            //        foreach (var message in user.Messages)
            //        {
            //            Models.MessageDto messageDto = new Models.MessageDto();
            //            messageDto.Content = message.Content;
            //            messageDto.MessageDateCreate = message.MessageDateCreate;
            //            messageDto.MessageID = message.MessageID;
            //            userDto.Messages.Add(messageDto);
            //        }
            //        resultat.Add(userDto);
            //    }
            //    return Ok(resultat);
            //}
            //else
            //{
            //    List<Models.UserWithoutMessagesDto> resultat = new List<Models.UserWithoutMessagesDto>();
            //    foreach (var user in listUser)
            //    {
            //        Models.UserWithoutMessagesDto userDto = new Models.UserWithoutMessagesDto();
            //        userDto.Name = user.Name;
            //        userDto.Surname = user.Surname;
            //        userDto.UserName = user.UserName;
            //        userDto.UserID = user.UserID;
            //        userDto.Birthday = user.Birthday;

            //        //...


            //        resultat.Add(userDto);
            //    }

            //    return Ok(resultat);

            //}
            OkObjectResult result;


            PagedList<Entities.User> listUser = _repository.GetUsers(includeMessage, pagination);
            if (includeMessage)
            {
                result = Ok(Mapper.Map<IEnumerable<UserDto>>(listUser));
            }
            else
            {
                result = Ok(Mapper.Map<IEnumerable<UserWithoutMessagesDto>>(listUser));
            }

            var paginationMetadata = new {
                CurrentPage = listUser.CurrentPage,
                TotalPages = listUser.TotalPages,
                PageSize = listUser.PageSize,
                TotalCount = listUser.TotalCount,
                PreviousPageLink = listUser.HasPrevious ? CreateUserResourceUri(pagination, ResourceUriType.PreviousPage) : null,
                NextPageLink = listUser.HasNext ? CreateUserResourceUri(pagination, ResourceUriType.NextPage) : null,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

            return result;

            //pour retourner du json
            //JsonResult resultat = new JsonResult(listUser);
            //pour fixer le httpStatusCode à la main
            //resultat.StatusCode = 404;

        }
        [HttpGet("{IdUser}")]
        public IActionResult GetUser(int idUser, bool includeMessage = false)
        {
            var user = _repository.GetUser(idUser,includeMessage);
            if (user == null)
            {
                return NotFound();
            }

            if (includeMessage)
            {
                var resultat = Mapper.Map<UserDto>(user);

                return Ok(resultat);
            }
            else
            {
                var resultat = Mapper.Map<UserWithoutMessagesDto>(user);

                return Ok(resultat);
            }
        }

        public enum ResourceUriType
        {
            PreviousPage,
            NextPage
        }

        private string CreateUserResourceUri(
           Pagination usersResourceParameters,
           ResourceUriType type)
        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return _urlHelper.Link("GetUsers",
                      new
                      {
                          pageNumber = usersResourceParameters.PageNumber - 1,
                          pageSize = usersResourceParameters.PageSize
                      });
                case ResourceUriType.NextPage:
                    return _urlHelper.Link("GetUsers",
                      new
                      {
                          pageNumber = usersResourceParameters.PageNumber + 1,
                          pageSize = usersResourceParameters.PageSize
                      });

                default:
                    return _urlHelper.Link("GetUsers",
                    new
                    {
                        pageNumber = usersResourceParameters.PageNumber,
                        pageSize = usersResourceParameters.PageSize
                    });
            }
        }
    }
}
