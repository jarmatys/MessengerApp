﻿using MessengerApp.Models.Messenger;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Infrastructure
{
    public class EfContext : IdentityDbContext
    {
        public EfContext(DbContextOptions<EfContext> options) : base(options) { }

        public DbSet<MessageModel> Messages { get; set; }

        // zaślepka na klasę bazową
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
