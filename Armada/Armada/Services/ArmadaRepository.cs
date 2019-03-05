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
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessages(int idUser)
        {
            throw new NotImplementedException();
        }

        ArmadaContext _ArmadaContext = new ArmadaContext();

        public User GetUser(int idUser)
        {
            
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            return _ArmadaContext.Users;
        }
    }
}
