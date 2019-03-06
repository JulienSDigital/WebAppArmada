using Armada.Entities;
using Armada.Helper;
using Armada.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public PagedList<User> GetUsers(bool includeMessage, Pagination pagination)
        {
            return PagedList<User>.Create(DataStore.Users.AsQueryable<User>(), 1, 100);
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
