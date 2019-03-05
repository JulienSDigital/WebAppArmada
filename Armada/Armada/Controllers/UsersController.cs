using Armada.Database;
using Armada.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var listUser = _repository.GetUsers(includeMessage);

            //JsonResult resultat = new JsonResult(listUser);
            
            //resultat.StatusCode = 404;

            return Ok(listUser);
        }
        [HttpGet("{IdUser}")]
        public IActionResult GetUser(int idUser, bool includeMessage = false)
        {
            var user = _repository.GetUser(idUser,includeMessage);
            if (user == null)
            {
                return NotFound();
            }

           
            return Ok(user);


        }


    }
}
