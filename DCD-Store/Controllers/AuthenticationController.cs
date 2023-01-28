﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DCD_Store.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCD_Store.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Signup()
        {
            return View("Signup");
        }

        public IActionResult Login()
        {
            return View("Login");
        }

        // POST: /<controller>/
        [HttpPost]
        public IActionResult Signup(string username, string email, string passwd, string age, string phone)
        {
            UserRepository userRepo = new UserRepository();
            User? user = userRepo.CreateUser(username, email, passwd, int.Parse(age), phone);
            if (user != null)
            {
                return View("Login");
            } else
            {
                return View("Error", "User With This Email Already Exists...");
            }
        }

        [HttpPost]
        public IActionResult Login(string email, string passwd)
        {
            UserRepository userRepo = new UserRepository();
            User? user = userRepo.Login(email, passwd);
            if (user != null)
            {
                return View("Home");
            }
            else
            {
                return View("Error", "User does not exist...");
            }
        }
    }
}

