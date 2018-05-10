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
    public class StudyCentersController : Controller
    {
        private Cem db = new Cem();

        // GET: StudyCenters
        public async Task<ActionResult> Index()
        {
            var studyCenter = db.StudyCenter.Include(s => s.country);
            return View(await studyCenter.ToListAsync());
        }

        // GET: StudyCenters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyCenter studyCenter = await db.StudyCenter.FindAsync(id);
            if (studyCenter == null)
            {
                return HttpNotFound();
            }
            return View(studyCenter);
        }

        // GET: StudyCenters/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "Name");
            return View();
        }

        // POST: StudyCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StudyCenterId,Name,CountryId")] StudyCenter studyCenter)
        {
            if (ModelState.IsValid)
            {
                db.StudyCenter.Add(studyCenter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "Name", studyCenter.CountryId);
            return View(studyCenter);
        }

        // GET: StudyCenters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyCenter studyCenter = await db.StudyCenter.FindAsync(id);
            if (studyCenter == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "Name", studyCenter.CountryId);
            return View(studyCenter);
        }

        // POST: StudyCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StudyCenterId,Name,CountryId")] StudyCenter studyCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studyCenter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Country, "CountryId", "Name", studyCenter.CountryId);
            return View(studyCenter);
        }

        // GET: StudyCenters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudyCenter studyCenter = await db.StudyCenter.FindAsync(id);
            if (studyCenter == null)
            {
                return HttpNotFound();
            }
            return View(studyCenter);
        }

        // POST: StudyCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            StudyCenter studyCenter = await db.StudyCenter.FindAsync(id);
            db.StudyCenter.Remove(studyCenter);
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
