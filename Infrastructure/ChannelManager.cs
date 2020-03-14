using MessengerApp.Models.Channel;
using MessengerApp.Models.Messenger;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Infrastructure
{
    public class ChannelManager
    {
        private readonly EfContext _context;

        public ChannelManager(EfContext context)
        {
            _context = context;
        }

        public async Task<List<ChannelModel>> GetAll()
        {
            return await _context.Channels.Include(x => x.OwnerUser).ToListAsync();
        }

        public async Task<ChannelModel> CreateChannel(ChannelModel result)
        {
            _context.Channels.Add(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<List<MessageModel>> GetChannelMessages(int Id)
        {
            var channel = await _context.Channels.FindAsync(Id);
            var messages = channel.Messages.ToList();
            return messages;
        }

        public async Task<ChannelModel> GetChannelById(int Id)
        {
            var channel = await _context.Channels.FindAsync(Id);
            //var channel = await _context.Channels.Include(x => x.Messages).Include(x => x.OwnerUser).FirstOrDefaultAsync(x => x.Id == Id);
            var messages = await _context.Messages.Where(x => x.Chanel == channel).Include(x => x.User).ToListAsync();
            channel.Messages = messages;
            return channel;
        }

    }
}
