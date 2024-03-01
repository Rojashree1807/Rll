using DALLibrary.Data;
using DALLibrary.Domain_Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DALLibrary.CRUD
{
    public class MessageCRUD
    {
        private readonly ClinicDbContext DbContext;
        public MessageCRUD()
        {
            DbContext = new ClinicDbContext();
        }
        public List<Message> GetAllMessages()
        {
            var obj = DbContext.Messages.ToList();
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }

        }
        public Message GetMessageById(int messageId)
        {
            var obj = DbContext.Messages.Find(messageId);
            if (obj != null)
            {
                return obj;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Message> GetById(int id)
        {
            IEnumerable<Message> messages = DbContext.Messages.
               OrderByDescending(mess => mess.MessageTime).
               Where(mess => mess.ReceiverId == id || mess.SenderId == id);
            return messages;
        }
        public IEnumerable<Message> GetBySenderIdAndRecieverId(int SenderId, int RecieverId)
        {
            IEnumerable<Message> messages = DbContext.Messages.OrderBy(mess => mess.Message_).Where(mess => (mess.ReceiverId == RecieverId && mess.SenderId == SenderId) || (mess.ReceiverId == SenderId && mess.SenderId == RecieverId));
            return messages;
        }
        public void AddMessage(Message message)
        {
            if (message != null)
            {
                DbContext.Messages.Add(message);
                DbContext.SaveChanges();
            }
        }

        public void UpdateMessage(Message message)
        {
            if (message != null)
            {
                DbContext.Entry(message).State = EntityState.Modified;
                DbContext.SaveChanges();
            }
        }

        public void DeleteMessage(int messageId)
        {
            var message = DbContext.Messages.Find(messageId);
            if (message != null)
            {
                DbContext.Messages.Remove(message);
                DbContext.SaveChanges();
            }
        }
    }
}
