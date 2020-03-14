using MessengerApp.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Channel
{
    public class SubscriptionModel
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ChannelModel Channel { get; set; }
    }
}
