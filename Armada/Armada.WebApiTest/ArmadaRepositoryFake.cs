using Armada.Entities;
using Armada.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Armada.WebApiTest
{
    public class ArmadaRepositoryFake : IArmadaRepository
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

        public User GetUser(int idUser, bool includeMessage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers(bool includeMessage)
        {
            return DataStore.Users;
        }

        public bool MessageExists(int idUser, int idMessage)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int idUser)
        {
            throw new NotImplementedException();
        }
    }
}
