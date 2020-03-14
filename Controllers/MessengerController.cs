using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using MessengerApp.Models.Account;
using MessengerApp.Models.Messenger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    [Authorize]
    public class MessengerController : Controller
    {
        private readonly MessengerManager _messenger;
        private readonly ChannelManager _channel;
        private readonly UserManager<User> _userManager;

        public MessengerController(MessengerManager manager, UserManager<User> userManager, ChannelManager channel)
        {
            _userManager = userManager;
            _messenger = manager;
            _channel = channel;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var mesList = await _messenger.GetAll();
            return View(mesList);
        }

        [HttpGet]
        public IActionResult Add(int Id)
        {
            // Id kanału
            ViewBag.ChannelId = Id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MessageViewModel result)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var channel = await _channel.GetChannelById(result.ChannelId);
                var message = new MessageModel
                {
                    AddDate = DateTime.Now,
                    Text = result.Text,
                    User = user,
                    Chanel = channel             
                };
                await _messenger.Add(message);

                return RedirectToAction("join", "Channel", new { Id = result.ChannelId});
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                await _messenger.Delete(id);
            }

            return RedirectToAction("List", "Messenger");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int Id)
        {
            var mes = await _messenger.GetById(Id);
            return View(mes);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MessageModel result)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var mes = await _messenger.GetById(result.Id);
                mes.User = user;
                mes.Text = result.Text;

                await _messenger.Edit(mes);
                return RedirectToAction("List", "Messenger");
            }
            return View(result);
        }
    }
}