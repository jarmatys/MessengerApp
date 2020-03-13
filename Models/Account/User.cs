﻿using MessengerApp.Models.Messenger;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Account
{
    public class User : IdentityUser
    {
        public ICollection<MessageModel> Messages { get; set; }
    }
}
