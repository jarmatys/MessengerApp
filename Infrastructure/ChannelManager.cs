﻿using MessengerApp.Models.Channel;
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
            return await _context.Channels.Include(x=> x.OwnerUser).ToListAsync();
        }

    }
}