using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Armada.Models;
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
            var listMessages = DataStore.Users.FirstOrDefault(u => u.UserID == idUser);
            if (listMessages == null)
            {
                return NotFound();
            }

            
            

            return Ok(listMessages.Messages);
        }
        
        [HttpGet("{idUser}/messages/{idMessage}")]
        public IActionResult GetMessage(int idUser, int idMessage)
        {
            var user = DataStore.Users.FirstOrDefault(u => u.UserID == idUser);
            if (user == null)
            {
                return NotFound();
            }
            var message = user.Messages.FirstOrDefault(m => m.MessageID == idMessage);
            if ( message == null)
            {   
                return NotFound();
            }

            
            return Ok(message);


        }
        //
        [HttpPost("{idUser}/message")]
        public IActionResult CreateMessage(int idUser, [FromBody] MessageForCreationDto message)
        {


            return null;
        }
        
    }
}