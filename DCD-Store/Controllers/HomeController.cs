using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCD_Store.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Authentication");
        }

        public IActionResult Signout()
        {
            return RedirectToAction("Signout", "Authentication");
        }
    }
}

