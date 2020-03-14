using MessengerApp.Models.Account;
using MessengerApp.Models.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Channel
{
    public class ChannelModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color  { get; set; }

        public bool isDefault { get; set; }

        public User OwnerUser { get; set; }

        public ICollection<SubscriptionModel> Subscription { get; set; }

        public ICollection<MessageModel> Messages { get; set; }

    }
}
