using Armada.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Services
{
    public interface IArmadaRepository
    {
        IEnumerable<User> GetUsers(bool includeMessage);
        User GetUser(int idUser, bool includeMessage);
        IEnumerable<Message> GetMessages(int idUser);
        Message GetMessage(int idUser, int idMessage);
        void AddMessage(int idUser, Message message);
        void DeleteMessage(Message message);
        bool UserExists(int idUser);
        bool MessageExists(int idUser,int idMessage);
        void Save();
    }
}
