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
    public class FamilyInfoesController : Controller
    {
        private Cem db = new Cem();

        // GET: FamilyInfoes
        public async Task<ActionResult> Index()
        {
            return View(await db.FamilyInfo.ToListAsync());
        }

        // GET: FamilyInfoes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyInfo familyInfo = await db.FamilyInfo.FindAsync(id);
            if (familyInfo == null)
            {
                return HttpNotFound();
            }
            return View(familyInfo);
        }

        // GET: FamilyInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FamilyInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FamilyInfoId,CriminalRecord,Residence,Work,Photo")] FamilyInfo familyInfo)
        {
            if (ModelState.IsValid)
            {
                db.FamilyInfo.Add(familyInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(familyInfo);
        }

        // GET: FamilyInfoes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyInfo familyInfo = await db.FamilyInfo.FindAsync(id);
            if (familyInfo == null)
            {
                return HttpNotFound();
            }
            return View(familyInfo);
        }

        // POST: FamilyInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FamilyInfoId,CriminalRecord,Residence,Work,Photo")] FamilyInfo familyInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(familyInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(familyInfo);
        }

        // GET: FamilyInfoes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FamilyInfo familyInfo = await db.FamilyInfo.FindAsync(id);
            if (familyInfo == null)
            {
                return HttpNotFound();
            }
            return View(familyInfo);
        }

        // POST: FamilyInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FamilyInfo familyInfo = await db.FamilyInfo.FindAsync(id);
            db.FamilyInfo.Remove(familyInfo);
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
