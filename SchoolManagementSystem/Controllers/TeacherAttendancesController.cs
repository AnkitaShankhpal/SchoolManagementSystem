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
    public class TeacherAttendancesController : Controller
    {
        private SchoolSystemDBEntities db = new SchoolSystemDBEntities();

        // GET: TeacherAttendances
        public ActionResult Index()
        {
            var teacherAttendances = db.TeacherAttendances.Include(t => t.Teacher);
            return View(teacherAttendances.ToList());
        }

        // GET: TeacherAttendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAttendance teacherAttendance = db.TeacherAttendances.Find(id);
            if (teacherAttendance == null)
            {
                return HttpNotFound();
            }
            return View(teacherAttendance);
        }

        // GET: TeacherAttendances/Create
        public ActionResult Create()
        {
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: TeacherAttendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeacherId,Status,Date")] TeacherAttendance teacherAttendance)
        {
            if (ModelState.IsValid)
            {
                db.TeacherAttendances.Add(teacherAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherAttendance.TeacherId);
            return View(teacherAttendance);
        }

        // GET: TeacherAttendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAttendance teacherAttendance = db.TeacherAttendances.Find(id);
            if (teacherAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherAttendance.TeacherId);
            return View(teacherAttendance);
        }

        // POST: TeacherAttendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeacherId,Status,Date")] TeacherAttendance teacherAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherAttendance.TeacherId);
            return View(teacherAttendance);
        }

        // GET: TeacherAttendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherAttendance teacherAttendance = db.TeacherAttendances.Find(id);
            if (teacherAttendance == null)
            {
                return HttpNotFound();
            }
            return View(teacherAttendance);
        }

        // POST: TeacherAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherAttendance teacherAttendance = db.TeacherAttendances.Find(id);
            db.TeacherAttendances.Remove(teacherAttendance);
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
