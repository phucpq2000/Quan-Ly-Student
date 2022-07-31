using QuanLyStudent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace QuanLyStudent.Controllers
{
    public class StudentController : Controller
    {
        private DBStudent db = new DBStudent();
        // GET: Student
        public ActionResult Index()
        {
            var listStudent = new DBStudent().Students.ToList();
            return View(listStudent);
        }

       
        // GET: Clothes/Details/5
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(ID);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }


        // GET: Clothes/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Clothes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Age,Address,Sex ,Phone,Email,IdClass,IdUser")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }



        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Clothes/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(ID);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            Student student = db.Students.Find(ID);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
