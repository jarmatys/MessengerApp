using MessengerApp.Models.Messenger;
using Microsoft.EntityFrameworkCore;
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

        public async Task<MessageModel> Add(MessageModel mes)
        {
            _context.Messages.Add(mes);
            await _context.SaveChangesAsync();
            return mes;
        }

        public async Task<MessageModel> Delete(int Id)
        {
            var mes = _context.Messages.Find(Id);

            _context.Remove(mes);
            await _context.SaveChangesAsync();

            return mes;
        }

        public async Task<MessageModel> GetById(int Id)
        {
            return await _context.Messages.FindAsync(Id);
        }
        public async Task<List<MessageModel>> GetAll()
        {
            return await _context.Messages.Include(x => x.User).ToListAsync();
        }

        public async Task<MessageModel> Edit(MessageModel mes)
        {
            _context.Messages.Update(mes);
            await _context.SaveChangesAsync();
            return mes;
        }
    }
}
