using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Armada.Database;
using Armada.Entities;
using Armada.Helper;
using Microsoft.EntityFrameworkCore;

namespace Armada.Services
{
    public class ArmadaRepository : IArmadaRepository
    {
        public void AddMessage(int idUser, Message message)
        {
            var user = GetUser(idUser,false);
            user.Messages.Add(message);
        }

        public void DeleteMessage(Message message)
        {
            _ArmadaContext.Messages.Remove(message);
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

        public User GetUser(int idUser, bool includeMessage)
        {
            if (includeMessage)
            {
                return _ArmadaContext.Users.Include(u => u.Messages).FirstOrDefault(u => u.UserID == idUser);
            }
            return _ArmadaContext.Users.FirstOrDefault(u => u.UserID == idUser);
        }

        public PagedList<User> GetUsers(bool includeMessage, Pagination pagination)
        {
            IQueryable<User> result;

            if (includeMessage)
            {
                result = _ArmadaContext.Users.Include(u => u.Messages);
            } else
            {
                result = _ArmadaContext.Users;
            }

            return PagedList<User>.Create(result, pagination.PageNumber, pagination.PageSize);
        }

        public bool UserExists(int idUser)
        {
            return GetUser(idUser, false) != null;
        }

        public bool MessageExists(int idUser, int idMessage)
        {
            return GetMessage(idUser,idMessage) != null;
        }

        public void Save()
        {
            _ArmadaContext.SaveChanges();
        }
    }
}
