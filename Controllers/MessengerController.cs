﻿using System;
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
        private readonly UserManager<User> _userManager;

        public MessengerController(MessengerManager manager, UserManager<User> userManager)
        {
            _userManager = userManager;
            _messenger = manager;
        }

        [HttpGet]
        public IActionResult List()
        {
            var mesList = _messenger.GetAll();
            return View(mesList);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MessageViewModel result)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var message = new MessageModel
                {
                    AddDate = DateTime.Now,
                    Text = result.Text,
                    User = user
                };
                await _messenger.Add(message);

                return RedirectToAction("List", "Messenger");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if(id > 0)
            {
                await _messenger.Delete(id);
            }

            return RedirectToAction("List", "Messenger");
        }
   
    }
}