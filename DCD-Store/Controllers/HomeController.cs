using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DCD_Store.Models;
using Microsoft.AspNetCore.Mvc;
using DCD_Store.Models.Interfces;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DCD_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        IAddRepository addRepo;

        public HomeController(IWebHostEnvironment environment, IAddRepository addRepo)
        {
            Environment = environment;
            this.addRepo = addRepo;
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

        public IActionResult ViewAdd()
        {

            List<string> list = new();
            list.Add("Custom Add");
            list.Add("This is the dummy Descritption");
            list.Add("DharamPura");
            list.Add("Weird One");
            list.Add("CR7");
            list.Add("+696969");
            list.Add("cr7@goat.com");
            list.Add("/file.jpg");

            return View("ViewAdd",list);
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
                string photo_path = "";
                foreach (var file in postedFiles)
                {
                    count++;
                    var fileName = Path.GetFileName(file.FileName);
                    var pathWithFileName = Path.Combine(path, fileName);
                    photo_path = fileName;
                    using (FileStream stream = new
                        FileStream(pathWithFileName,
                        FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                // preparing data
                List<string> list = new();
                list.Add(add.Title);
                list.Add(add.Description);
                list.Add(add.Category);
                list.Add(add.City);

                var context = new DcdStoreContext();

                List<User> u = (List<User>)context.Users.Where(u => u.ID == add.UserId).ToList();

                list.Add(u[0].Username);
                list.Add(u[0].Phone);
                list.Add(u[0].Email);
                list.Add("/Uploads/" + add.Id + "/" + photo_path);
                addRepo.UpdatePhotoPath(add.Id, photo_path);

                //return View("Error", "Something Happend");
                return View("ViewAdd", list);
            }
            else
            {
                return View("Error", "Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult CategoryDetail(string category)
        {
            List<Add> adds = addRepo.ViewAdds(category);
            return View("Category", adds);
        }
    }
}

