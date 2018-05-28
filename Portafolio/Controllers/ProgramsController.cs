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
    public class ProgramsController : Controller
    {
        private Cem db = new Cem();

        // GET: Programs
        public async Task<ActionResult> Index()
        {
            var program = db.Program.Include(p => p.Period).Include(p => p.ProgramStatus).Include(p => p.StudyCenter);
            return View(await program.ToListAsync());
        }


        public ActionResult PublicatedPrograms()
        {
            var programs = db.Program.Where(p => p.ProgramStatus.StatusName.Contains("publicated"));
            return View(programs);
        }



        // GET: Programs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Program.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // GET: Programs/Create
        public ActionResult Create()
        {
            ViewBag.PeriodId = new SelectList(db.Period, "PeriodId", "Name");
            ViewBag.ProgramStatusId = new SelectList(db.ProgramStatus, "ProgramStatusId", "StatusName");
            ViewBag.StudyCenterId = new SelectList(db.StudyCenter, "StudyCenterId", "Name");
            return View();
        }

        // POST: Programs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProgramId,Name,Description,Spaces,PeriodId,ProgramStatusId,StudyCenterId")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Program.Add(program);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PeriodId = new SelectList(db.Period, "PeriodId", "Name", program.PeriodId);
            ViewBag.ProgramStatusId = new SelectList(db.ProgramStatus, "ProgramStatusId", "StatusName", program.ProgramStatusId);
            ViewBag.StudyCenterId = new SelectList(db.StudyCenter, "StudyCenterId", "Name", program.StudyCenterId);
            return View(program);
        }

        // GET: Programs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Program.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            ViewBag.PeriodId = new SelectList(db.Period, "PeriodId", "Name", program.PeriodId);
            ViewBag.ProgramStatusId = new SelectList(db.ProgramStatus, "ProgramStatusId", "StatusName", program.ProgramStatusId);
            ViewBag.StudyCenterId = new SelectList(db.StudyCenter, "StudyCenterId", "Name", program.StudyCenterId);
            return View(program);
        }

        // POST: Programs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProgramId,Name,Description,Spaces,PeriodId,ProgramStatusId,StudyCenterId")] Program program)
        {
            if (ModelState.IsValid)
            {
                db.Entry(program).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PeriodId = new SelectList(db.Period, "PeriodId", "Name", program.PeriodId);
            ViewBag.ProgramStatusId = new SelectList(db.ProgramStatus, "ProgramStatusId", "StatusName", program.ProgramStatusId);
            ViewBag.StudyCenterId = new SelectList(db.StudyCenter, "StudyCenterId", "Name", program.StudyCenterId);
            return View(program);
        }

        // GET: Programs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Program program = await db.Program.FindAsync(id);
            if (program == null)
            {
                return HttpNotFound();
            }
            return View(program);
        }

        // POST: Programs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Program program = await db.Program.FindAsync(id);
            db.Program.Remove(program);
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
