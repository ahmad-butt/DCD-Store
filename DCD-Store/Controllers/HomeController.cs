using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DCD_Store.Models;
using post_add.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCD_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment Environment;

        public HomeController(IWebHostEnvironment environment)
        {

            Environment = environment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Index");
        }

        public IActionResult PostAdd()
        {
            return View("PostAdd");
        }

        public IActionResult Login()
        {
            return RedirectToAction("Login", "Authentication");
        }

        public IActionResult Signout()
        {
            return RedirectToAction("Signout", "Authentication");
        }

        [HttpPost]
        public IActionResult PostAdd(string title, string description, string category, string city, List<IFormFile> postedFiles)
        {
            int uid = int.Parse(HttpContext.Request.Cookies["uid"]);
            AddRepository addRepo = new AddRepository();
            Add? add = addRepo.PostAdd(uid:uid, title: title, description: description, city: city, category: category); 
            if (add != null)
            {
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                path = Path.Combine(path, "" + add.Id);
                Directory.CreateDirectory(path);

                int count = 0;
                foreach (var file in postedFiles)
                {
                    count++;
                    var fileName = Path.GetFileName(file.FileName);
                    var pathWithFileName = Path.Combine(path, fileName);
                    using (FileStream stream = new
                        FileStream(pathWithFileName,
                        FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return View("Welcome", "Add created successfully...");
            }
            else
            {
                return View("Error", "Something went wrong");
            }
        }
    }
}

