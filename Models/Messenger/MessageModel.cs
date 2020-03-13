using MessengerApp.Models.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Messenger
{
    public class MessageModel
    {
        public int Id { get; set; }

        [Required]
        public DateTime AddDate { get; set; }

        [Required]
        public string Text { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
