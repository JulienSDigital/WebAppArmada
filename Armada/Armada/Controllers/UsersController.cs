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

namespace Armada.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private ILogger<MessagesController> _logger;
        private IArmadaRepository _repository;

        public UsersController(ILogger<MessagesController> logger, IArmadaRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet()]
        public IActionResult GetUsers(bool includeMessage = false)
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

            
            IEnumerable<Entities.User> listUser = _repository.GetUsers(includeMessage);
            if (includeMessage)
            {
                var resultat = Mapper.Map<IEnumerable<UserDto>>(listUser);
                
                return Ok(resultat);
            }
            else
            {
                var resultat = Mapper.Map<IEnumerable<UserWithoutMessagesDto>>(listUser);

                return Ok(resultat);
            }


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
    }
}
