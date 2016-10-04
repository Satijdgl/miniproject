using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniProject.Models;
using MiniProject.DAL;
using PagedList;

namespace MiniProject.Controllers
{
    public class AttendanceController : Controller
    {
        private AttendanceContext db = new AttendanceContext();

        // GET: /Attendance/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var attendance = from s in db.Attendances
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                attendance = attendance.Where(s => s.Student.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                //case "name_desc":
                //    attendance = attendance.OrderBy(s => s.Student.Name);
                //    break;
                case "Date":
                    attendance = attendance.OrderByDescending(s => s.Date);
                    break;
                case "date_desc":
                    attendance = attendance.OrderByDescending(s => s.Date);
                    break;
                default:
                    attendance = attendance.OrderByDescending(s => s.Date);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(attendance.ToPagedList(pageNumber,pageSize));
        }

        // GET: /Attendance/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: /Attendance/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name");
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name");
            return View();
        }

        // POST: /Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AttendanceID,StudentID,SubjectID,Date,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", attendance.StudentID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name", attendance.SubjectID);
            return View(attendance);
        }

        // GET: /Attendance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", attendance.StudentID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name", attendance.SubjectID);
            return View(attendance);
        }

        // POST: /Attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AttendanceID,StudentID,SubjectID,Date,Status")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "ID", "Name", attendance.StudentID);
            ViewBag.SubjectID = new SelectList(db.Subjects, "SubjectID", "Name", attendance.SubjectID);
            return View(attendance);
        }

        // GET: /Attendance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: /Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
