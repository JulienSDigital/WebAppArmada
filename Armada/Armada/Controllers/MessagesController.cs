using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Armada.Entities;
using Armada.Models;
using Armada.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Armada.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private ILogger<MessagesController> _logger;
        private IMailService _mail;
        private IArmadaRepository _repository;

        public MessagesController(ILogger <MessagesController> logger, IMailService mail, IArmadaRepository repository)
        {
            _logger = logger;
            _mail = mail;
            _repository = repository;
        }

        [HttpGet("{idUser}/messages")]
        public IActionResult GetMessages(int idUser)
        {
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }
            var messages = _repository.GetMessages(idUser);
            if (messages == null)
            {
                _logger.LogInformation("Pas de messages pour l'id" + idUser);
                return NotFound();
            }
            return Ok(messages);
        }

        [HttpGet("{idUser}/messages/{idMessage}", Name = nameof(GetMessage))]
        public IActionResult GetMessage(int idUser, int idMessage)
        {
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }

            var message = _repository.GetMessage( idMessage:idMessage, idUser:idUser);
            if (message == null)
            {
                return NotFound();
            }


            return Ok(message);


        }
        
        [HttpPost("{idUser}/messages")]
        public IActionResult CreateMessage(int idUser, [FromBody] MessageForCreationDto message)
        {
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }

            var user = _repository.GetUser(idUser, false);


            if (message.MessageDateCreate.Year < 2019)
            {
                ModelState.AddModelError("year", "L'année n'est pas bonne");

            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdMessage = new Message();
            createdMessage.Content = message.Content;
            createdMessage.MessageDateCreate = message.MessageDateCreate;
            _repository.AddMessage(idUser, createdMessage);
            _repository.Save();

            _mail.Send("Nouveau message", "Un nouveau message de crée : " + createdMessage.Content);
            return CreatedAtRoute(nameof(GetMessage), new { idUser = idUser, idMessage = createdMessage.MessageID }, createdMessage);
          
        }
        [HttpPut("{idUser}/messages/{idMessage}")]
        public IActionResult UpdateMessage(int idUser, int idMessage, [FromBody] MessageForCreationDto message)
        { 
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }

            var user = _repository.GetUser(idUser, false);

            if (!_repository.MessageExists(idUser, idMessage))
            {
                return NotFound();
            }

            var currentMessage = _repository.GetMessage(idUser, idMessage);

            currentMessage.Content = message.Content;
            currentMessage.MessageDateCreate = message.MessageDateCreate;
            _repository.Save();

            return NoContent();
        }
        [HttpPatch("{idUser}/messages/{idMessage}")]
        public IActionResult UpdatePartiallyMessage(int idUser, int idMessage, [FromBody] JsonPatchDocument<Message> patchDocument)
        {
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }

            var user = _repository.GetUser(idUser, false);

            if (!_repository.MessageExists(idUser, idMessage))
            {
                return NotFound();
            }

            var currentMessage = _repository.GetMessage(idUser, idMessage);

            var saveOldMessage = new Message();
            saveOldMessage.Content = currentMessage.Content;
            saveOldMessage.MessageDateCreate = currentMessage.MessageDateCreate;
            
            patchDocument.ApplyTo(currentMessage, ModelState);

            if (currentMessage.MessageDateCreate.Year < 2019)
            {
                currentMessage.MessageDateCreate = saveOldMessage.MessageDateCreate;
                ModelState.AddModelError("year", "L'année n'est pas bonne");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{idUser}/messages/{idMessage}")]
        public IActionResult DeleteMessage(int idUser, int idMessage)
        {
            if (!_repository.UserExists(idUser))
            {
                _logger.LogInformation("Pas de user pour l'id" + idUser);
                return NotFound();
            }
            var user = _repository.GetUser(idUser, true);


            if (! _repository.MessageExists(idUser,idMessage))
            {
                return NotFound();
            }

            var currentMessage = _repository.GetMessage(idUser, idMessage);


            _repository.DeleteMessage(currentMessage);
            _repository.Save();
            return NoContent();

        }
    }
}