using MessengerApp.Models.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Infrastructure
{
    public class MessengerManager
    {
        private readonly EfContext _context;

        public MessengerManager(EfContext context)
        {
            _context = context;
        }

        public void Add(MessageModel mes)
        {
            mes.AddDate = DateTime.Now;
            _context.Messages.Add(mes);
            _context.SaveChanges();
        }

        public List<MessageModel> GetAll()
        {
            return _context.Messages.ToList();
        }
    }
}
