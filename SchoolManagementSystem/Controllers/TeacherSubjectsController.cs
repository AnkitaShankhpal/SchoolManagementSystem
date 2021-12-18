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
    public class TeacherSubjectsController : Controller
    {
        private SchoolSystemDBEntities db = new SchoolSystemDBEntities();

        // GET: TeacherSubjects
        public ActionResult Index()
        {
            var teacherSubjects = db.TeacherSubjects.Include(t => t.Class).Include(t => t.Subject).Include(t => t.Teacher);
            return View(teacherSubjects.ToList());
        }

        // GET: TeacherSubjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            if (teacherSubject == null)
            {
                return HttpNotFound();
            }
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName");
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName");
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name");
            return View();
        }

        // POST: TeacherSubjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassId,subjectId,TeacherId")] TeacherSubject teacherSubject)
        {
            if (ModelState.IsValid)
            {
                db.TeacherSubjects.Add(teacherSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", teacherSubject.subjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            if (teacherSubject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", teacherSubject.subjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // POST: TeacherSubjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassId,subjectId,TeacherId")] TeacherSubject teacherSubject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.Classes, "ClassId", "ClassName", teacherSubject.ClassId);
            ViewBag.subjectId = new SelectList(db.Subjects, "subjectId", "SubjectName", teacherSubject.subjectId);
            ViewBag.TeacherId = new SelectList(db.Teachers, "TeacherId", "Name", teacherSubject.TeacherId);
            return View(teacherSubject);
        }

        // GET: TeacherSubjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            if (teacherSubject == null)
            {
                return HttpNotFound();
            }
            return View(teacherSubject);
        }

        // POST: TeacherSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherSubject teacherSubject = db.TeacherSubjects.Find(id);
            db.TeacherSubjects.Remove(teacherSubject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Show()
        {
            return View();
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
