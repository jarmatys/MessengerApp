using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    [Authorize]
    public class MessengerController : Controller
    {
        private readonly MessengerManager _messenger;

        public MessengerController(MessengerManager manager)
        {
            _messenger = manager;
        }

        public IActionResult List()
        {
            var mesList = _messenger.GetAll();
            return View(mesList);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}