using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyStudent.Models;
using System.Data.Entity;

namespace QuanLyStudent.Controllers
{
    public class LoginController : Controller
    {
        DBStudent db = new DBStudent();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherise(User userModel)
        {
            User user = db.Users.Where(x => x.Username == userModel.Username && x.Password == userModel.Password).FirstOrDefault();
            var userDetails = user;
            if (userDetails == null)
            {
                ViewBag.FailMessage = "Login Fails!!!";
                return View("Index", userModel);
            }
            else
            {
                Session["IdUser"] = userDetails.IdUser;
                Session["Username"] = userDetails.Username;
                return RedirectToAction("Index", "Student");
            }
        }

        public ActionResult Logout() 
        {
            int IdUser = (int)Session["IdUser"];
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}