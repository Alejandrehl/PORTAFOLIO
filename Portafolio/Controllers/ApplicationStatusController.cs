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
    public class ApplicationStatusController : Controller
    {
        private Cem db = new Cem();

        // GET: ApplicationStatus
        public async Task<ActionResult> Index()
        {
            return View(await db.ApplicationStatus.ToListAsync());
        }

        // GET: ApplicationStatus/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationStatus applicationStatus = await db.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return HttpNotFound();
            }
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ApplicationStatusId,StatusName")] ApplicationStatus applicationStatus)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationStatus.Add(applicationStatus);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationStatus applicationStatus = await db.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return HttpNotFound();
            }
            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ApplicationStatusId,StatusName")] ApplicationStatus applicationStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationStatus).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationStatus);
        }

        // GET: ApplicationStatus/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationStatus applicationStatus = await db.ApplicationStatus.FindAsync(id);
            if (applicationStatus == null)
            {
                return HttpNotFound();
            }
            return View(applicationStatus);
        }

        // POST: ApplicationStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApplicationStatus applicationStatus = await db.ApplicationStatus.FindAsync(id);
            db.ApplicationStatus.Remove(applicationStatus);
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
