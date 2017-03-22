using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ErieHackChloroData.Models;
using Microsoft.AspNet.Identity;

namespace ErieHackChloroData.Controllers
{
    public class ChlorophyllSamplesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChlorophyllSamples
        public async Task<ActionResult> Index()
        {
            return View(await db.ChlorophyllSamples.ToListAsync());
        }

        // GET: ChlorophyllSamples/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChlorophyllSample chlorophyllSample = await db.ChlorophyllSamples.FindAsync(id);
            if (chlorophyllSample == null)
            {
                return HttpNotFound();
            }
            return View(chlorophyllSample);
        }

        // GET: ChlorophyllSamples/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChlorophyllSamples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SampleId,Lake,Site,TimeEntered,Parameter,EntryCode,Result,Unit,UserId")] ChlorophyllSample chlorophyllSample)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                ApplicationUser currentuser = db.Users.SingleOrDefault(t => t.Id == userid);
                chlorophyllSample.ApplicationUser = currentuser;
                db.ChlorophyllSamples.Add(chlorophyllSample);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(chlorophyllSample);
        }

        // GET: ChlorophyllSamples/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChlorophyllSample chlorophyllSample = await db.ChlorophyllSamples.FindAsync(id);
            if (chlorophyllSample == null)
            {
                return HttpNotFound();
            }
            return View(chlorophyllSample);
        }

        // POST: ChlorophyllSamples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SampleId,Lake,Site,TimeEntered,Parameter,EntryCode,Result,Unit")] ChlorophyllSample chlorophyllSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chlorophyllSample).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(chlorophyllSample);
        }

        // GET: ChlorophyllSamples/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChlorophyllSample chlorophyllSample = await db.ChlorophyllSamples.FindAsync(id);
            if (chlorophyllSample == null)
            {
                return HttpNotFound();
            }
            return View(chlorophyllSample);
        }

        // POST: ChlorophyllSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ChlorophyllSample chlorophyllSample = await db.ChlorophyllSamples.FindAsync(id);
            db.ChlorophyllSamples.Remove(chlorophyllSample);
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
