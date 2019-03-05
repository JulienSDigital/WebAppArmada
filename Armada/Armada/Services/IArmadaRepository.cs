using Armada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Services
{
    public interface IArmadaRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(int idUser);
        IEnumerable<Message> GetMessages(int idUser);
        Message GetMessage(int idUser, int idMessage);
        void AddMessage(int idUser, Message message);
        void DeleteMessage(Message message);
    }
}
