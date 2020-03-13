using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessengerApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace MessengerApp.Controllers
{
    public class MessengerController : Controller
    {
        private readonly MessengerManager _messenger;

        public MessengerController(MessengerManager manager)
        {
            _messenger = manager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}