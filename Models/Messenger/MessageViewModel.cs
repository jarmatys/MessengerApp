using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Messenger
{
    public class MessageViewModel
    {
        [Required]
        [Display(Name = "Treść wiadomości")]
        public string Text { get; set; }
    }
}
