using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net; 
using System.Web;
using System.Web.Mvc;
using BTH8.Models;

namespace BTH8.Controllers 
{
    public class EmployeeController : Controller
    {
        private QL_NhanSuEntities db = new QL_NhanSuEntities();

        public ActionResult Index()
        {
            var tbl_Employee = db.tbl_Employee.Include(t => t.tbl_Deparment);
            return View(tbl_Employee.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        public ActionResult Create()
        {
            ViewBag.Deptid = new SelectList(db.tbl_Deparment, "Deptid", "Name");
            ViewBag.GenderList = new SelectList(new List<string> { "Nam", "Nữ" });
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Deptid = new SelectList(db.tbl_Deparment, "Deptid", "Name");

            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem { Text = "Nam", Value = "Nam" });
            genderList.Add(new SelectListItem { Text = "Nữ", Value = "Nữ" });
            ViewBag.GenderList = new SelectList(genderList, "Value", "Text");

            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }

            ViewBag.Deptid = new SelectList(db.tbl_Deparment, "Deptid", "Name", tbl_Employee.Deptid);
            ViewBag.GenderList = new SelectList(new List<string> { "Nam", "Nữ" }, tbl_Employee.Gender);
            return View(tbl_Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Gender,City,Deptid")] tbl_Employee tbl_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Deptid = new SelectList(db.tbl_Deparment, "Deptid", "Name", tbl_Employee.Deptid);
            ViewBag.GenderList = new SelectList(new List<string> { "Nam", "Nữ" }, tbl_Employee.Gender);
            return View(tbl_Employee);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            if (tbl_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            db.tbl_Employee.Remove(tbl_Employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}