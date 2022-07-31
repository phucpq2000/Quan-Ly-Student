using QuanLyStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyStudent.Controllers
{
    public class RegisterController : Controller
    {
        DBStudent db = new DBStudent();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterIndex(User userModel)
        {
            if (db.Users.Any(x => x.Username == userModel.Username))
            {
                ViewBag.FailMessage = "Username already exist!!!";
                return View("Index", userModel);
            }
            db.Users.Add(userModel);
            db.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}