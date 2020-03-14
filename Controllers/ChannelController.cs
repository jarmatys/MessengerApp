using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    public class ChannelController : Controller
    {
        private readonly ChannelManager _channel;
        public ChannelController(ChannelManager channel)
        {
            _channel = channel;
        }

        public async Task<IActionResult> List()
        {
            var channels = await _channel.GetAll();
            return View(channels);
        }

        public async Task<IActionResult> Join(int Id)
        {
            var channel = await _channel.GetChannelById(Id);
            return View(channel);
        }
    }
}