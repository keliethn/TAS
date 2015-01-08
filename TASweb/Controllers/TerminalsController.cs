using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TASweb.Models;

namespace TASweb.Controllers
{
    public class TerminalsController : Controller
    {
        private TASEntities db = new TASEntities();

        // GET: Terminals
        public ActionResult Index()
        {
            var terminals = db.Terminals.Include(t => t.Location);
            return View(terminals.ToList());
        }

        // GET: Terminals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = db.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        // GET: Terminals/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName");
            return View();
        }

        // POST: Terminals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TerminalID,UUID,TicketSerie,LocationID,CompanyID,ShiftStatus,Status")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                db.Terminals.Add(terminal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", terminal.LocationID);
            return View(terminal);
        }

        // GET: Terminals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = db.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", terminal.LocationID);
            return View(terminal);
        }

        // POST: Terminals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TerminalID,UUID,TicketSerie,LocationID,CompanyID,ShiftStatus,Status")] Terminal terminal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(terminal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "LocationName", terminal.LocationID);
            return View(terminal);
        }

        // GET: Terminals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Terminal terminal = db.Terminals.Find(id);
            if (terminal == null)
            {
                return HttpNotFound();
            }
            return View(terminal);
        }

        // POST: Terminals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Terminal terminal = db.Terminals.Find(id);
            db.Terminals.Remove(terminal);
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
