using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Armada.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet("{idUser}/messages")]
        public IActionResult GetMessages(int idUser)
        {
            var listMessages = DataStore.Users;

            JsonResult resultat = new JsonResult(listMessages);
            //resultat.StatusCode = 404;

            return resultat;
        }
        /*
        [HttpGet("{IdUser}")]
        public IActionResult GetMessage(int idMessage)
        {
            var user = DataStore.Users.FirstOrDefault(u => u.UserID == idUser);
            if (user == null)
            {
                return NotFound();
            }

            JsonResult resultat = new JsonResult(user);
            return resultat;


        }
        */
    }
}