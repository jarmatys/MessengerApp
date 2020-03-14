using MessengerApp.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Messenger
{
    public class ChanelModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Color  { get; set; }

        public User OwnerUser { get; set; }

        public ICollection<SubscriptionModel> Subscription { get; set; }

    }
}
