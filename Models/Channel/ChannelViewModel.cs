using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApp.Models.Channel
{
    public class ChannelViewModel
    {
        [Required]
        public string Color { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
