using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolManagementSystem;

namespace SchoolManagementSystem.Controllers
{
    public class StudentAttendancesController : Controller
    {
        private SchoolSystemDBEntities db = new SchoolSystemDBEntities();

        // GET: StudentAttendances
        public ActionResult Index()
        {
            var studentAttendances = db.StudentAttendances.Include(s => s.Class).Include(s => s.Subject);
            return View(studentAttendances.ToList());
        }

        // GET: StudentAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName");
            return View();
        }

        // POST: StudentAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,subjectId,RollNo,Status,Date")] StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.StudentAttendances.Add(studentAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", studentAttendance.subjectId);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", studentAttendance.subjectId);
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,subjectId,RollNo,Status,Date")] StudentAttendance studentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", studentAttendance.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", studentAttendance.subjectId);
            return View(studentAttendance);
        }

        // GET: StudentAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            if (studentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentAttendance);
        }

        // POST: StudentAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentAttendance studentAttendance = db.StudentAttendances.Find(id);
            db.StudentAttendances.Remove(studentAttendance);
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
