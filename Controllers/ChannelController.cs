﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using MessengerApp.Models.Account;
using MessengerApp.Models.Channel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    [Authorize]
    public class ChannelController : Controller
    {
        private readonly ChannelManager _channel;
        private readonly UserManager<User> _userManager;
        private readonly SubscribeManager _subscription;

        public ChannelController(ChannelManager channel, UserManager<User> userManager, SubscribeManager sub)
        {
            _userManager = userManager;
            _channel = channel;
            _subscription = sub;
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

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ChannelViewModel result)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                var newChannel = new ChannelModel
                {
                    Color = result.Color,
                    Name = result.Name,
                    OwnerUser = user,
                    isDefault = false
                };
                await _channel.CreateChannel(newChannel);
                return RedirectToAction("List", "Channel");
            }
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Subscribe(int Id)
        {
            var channel = await _channel.GetChannelById(Id);
            var user = await _userManager.GetUserAsync(User);

            await _subscription.SubscribeChannel(user, channel);

            return RedirectToAction("Subscribes", "Channel");
        }

        [HttpGet]
        public async Task<IActionResult> Subscribes()
        {
            var user = await _userManager.GetUserAsync(User);
            var channels = await _subscription.GetSubscribeChannel(user);
            return View(channels);
        }

    }
}