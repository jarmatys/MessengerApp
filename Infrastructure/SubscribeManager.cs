using MessengerApp.Models.Account;
using MessengerApp.Models.Channel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Infrastructure
{
    public class SubscribeManager
    {
        private readonly EfContext _context;

        public SubscribeManager(EfContext context)
        {
            _context = context;
        }

        public async Task<SubscriptionModel> SubscribeChannel(User user, ChannelModel channel)
        {
            var temp = new SubscriptionModel
            {
                User = user,
                Channel = channel
            };

            _context.Subscriptions.Add(temp);
            await _context.SaveChangesAsync();

            return temp;
        }

        public async Task<List<ChannelModel>> GetSubscribeChannel(User user)
        {
            var channels = await _context.Subscriptions.Where(x => x.User == user).Include(x => x.Channel).Select(x => x.Channel).ToListAsync();
            return channels;
        }

    }
}
