using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Armada.Entities;

namespace Armada.Services
{
    public class ArmadaRepository : IArmadaRepository
    {
        public void AddMessage(int idUser, Message message)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public Message GetMessage(int idUser, int idMessage)
        {
            //var messages = _ArmadaContext.Messages.Where(m => m.UserID == idUser);
            //var message = messages.FirstOrDefault(m => m.MessageID == idMessage);

            //var message = _ArmadaContext.Messages.FirstOrDefault(m => m.UserID == idUser && m.MessageID == idMessage);

            var messages = from m in _ArmadaContext.Messages
                          where (m.UserID == idUser && m.MessageID == idMessage)
                          select m;

            return messages.FirstOrDefault();
        }

        public IEnumerable<Message> GetMessages(int idUser)
        {
            //var messages = _ArmadaContext.Messages.Where(m => m.UserID == idUser);
            var messages = from m in _ArmadaContext.Messages 
                           where( m.UserID == idUser)
                           select m;

            return messages;
        }
        
        ArmadaContext _ArmadaContext = new ArmadaContext();

        public User GetUser(int idUser)
        {
            var user = _ArmadaContext.Users.FirstOrDefault(u => u.UserID == idUser);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _ArmadaContext.Users;
        }

        public bool UserExists(int idUser)
        {
            return GetUser(idUser) != null;
        }
    }
}
