using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portafolio.Models;

namespace Portafolio.Controllers
{
    public class StudentApplicationsController : Controller
    {
        private Cem db = new Cem();

        // GET: StudentApplications
        public async Task<ActionResult> Index()
        {
            var studentApplication = db.StudentApplication.Include(s => s.ApplicationStatus).Include(s => s.Program);
            return View(await studentApplication.ToListAsync());
        }

        // GET: StudentApplications/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = await db.StudentApplication.FindAsync(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            return View(studentApplication);
        }

        // GET: StudentApplications/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatus, "ApplicationStatusId", "StatusName");
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name");
            return View();
        }

        // POST: StudentApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudentApplicationId,ApplicationStatusId,StudentName,ProgramId")] StudentApplication studentApplication)
        {
            if (ModelState.IsValid)
            {
                db.StudentApplication.Add(studentApplication);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatus, "ApplicationStatusId", "StatusName", studentApplication.ApplicationStatusId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentApplication.ProgramId);
            return View(studentApplication);
        }

        // GET: StudentApplications/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = await db.StudentApplication.FindAsync(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatus, "ApplicationStatusId", "StatusName", studentApplication.ApplicationStatusId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentApplication.ProgramId);
            return View(studentApplication);
        }

        // POST: StudentApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudentApplicationId,ApplicationStatusId,StudentName,ProgramId")] StudentApplication studentApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentApplication).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationStatusId = new SelectList(db.ApplicationStatus, "ApplicationStatusId", "StatusName", studentApplication.ApplicationStatusId);
            ViewBag.ProgramId = new SelectList(db.Program, "ProgramId", "Name", studentApplication.ProgramId);
            return View(studentApplication);
        }

        // GET: StudentApplications/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentApplication studentApplication = await db.StudentApplication.FindAsync(id);
            if (studentApplication == null)
            {
                return HttpNotFound();
            }
            return View(studentApplication);
        }

        // POST: StudentApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudentApplication studentApplication = await db.StudentApplication.FindAsync(id);
            db.StudentApplication.Remove(studentApplication);
            await db.SaveChangesAsync();
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
