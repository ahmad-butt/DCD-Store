using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DCD_Store.Models;
using Microsoft.AspNetCore.Mvc;
using DCD_Store.Models.Interfces;
using Microsoft.EntityFrameworkCore;

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
            List<Add> adds = addRepo.Top3Adds();
            return View("Index", adds);
        }

        public IActionResult PostAdd()
        {
            return View("PostAdd");
        }

        public IActionResult EditAdd(int id)
        {
            Add add = addRepo.GetAdd(id);
            return View("EditAdd", add);
        }

        public IActionResult MyAdds()
        {
            List<Add> adds = addRepo.MyAdds(int.Parse(Request.Cookies["uid"]));
            return View("ListAddView", adds);
        }

        public IActionResult Delete(int id)
        {
            addRepo.RemoveAdd(id);

            return MyAdds();
        }

        public IActionResult ViewAdd(int id)
        {

            Add add = addRepo.GetAdd(id);

            List<string> list = new();
            list.Add(add.Title);
            list.Add(add.Description);
            list.Add(add.City);
            list.Add(add.Category);

            var context = new DcdStoreContext();
            List<User> u = (List<User>)context.Users.Where(u => u.ID == add.UserId).ToList();

            list.Add(u[0].Username);
            list.Add(u[0].Phone);
            list.Add(u[0].Email);
            list.Add("/Uploads/" + add.Id + "/" + add.PhotoPath);
            
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
        public IActionResult PostAdd([FromForm] string title,[FromForm] string description, [FromForm] string category, [FromForm] string city, [FromForm] IFormFile file)
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

                string photo_path = "";
                if (file != null)
                {
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

                addRepo.UpdatePhotoPath(add.Id, photo_path);

                //return View("Error", "Something Happend");
                return ViewAdd(add.Id);
            }
            else
            {
                return View("Error", "Something went wrong");
            }
        }

        [HttpPost]
        public IActionResult EditAdd(Add add, [FromForm] IFormFile file)
        {
            int uid = int.Parse(HttpContext.Request.Cookies["uid"]);
                     
            if (add != null)
            {
                addRepo.UpdateAdd(add);

                if (file != null)
                {
                    addRepo.UpdatePhotoPath(add.Id, Path.GetFileName(file.FileName));
                    string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                    path = Path.Combine(path, "" + add.Id);
                    path = Path.Combine(path, Path.GetFileName(file.FileName));
                    using (FileStream stream = new
                    FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return ViewAdd(add.Id);
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
            return View("ListAddView", adds);
        }

        public IActionResult SearchAdds(string txt)
        {
            List<Add> adds = addRepo.SearchAdds(txt);
            //List<Add> adds = addRepo.ViewAdds("eh");

            return View("ListAddView", adds);
        }

    }
}

