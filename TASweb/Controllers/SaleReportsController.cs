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
    public class SaleReportsController : Controller
    {
        private TASEntities db = new TASEntities();

        // GET: SaleReports
        public ActionResult Index()
        {
            var saleReports = db.SaleReports.Include(s => s.Game).Include(s => s.SaleReportStatus);
            return View(saleReports.ToList());
        }

        // GET: SaleReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReport saleReport = db.SaleReports.Find(id);
            if (saleReport == null)
            {
                return HttpNotFound();
            }
            return View(saleReport);
        }

        // GET: SaleReports/Create
        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "GameID", "HomeClubName");
            ViewBag.Status = new SelectList(db.SaleReportStatuses, "SaleReportStatusID", "StatusName");
            return View();
        }

        // POST: SaleReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,ReportDate,GameID,Status")] SaleReport saleReport)
        {
            if (ModelState.IsValid)
            {
                db.SaleReports.Add(saleReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "GameID", "HomeClubName", saleReport.GameID);
            ViewBag.Status = new SelectList(db.SaleReportStatuses, "SaleReportStatusID", "StatusName", saleReport.Status);
            return View(saleReport);
        }

        // GET: SaleReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReport saleReport = db.SaleReports.Find(id);
            if (saleReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "HomeClubName", saleReport.GameID);
            ViewBag.Status = new SelectList(db.SaleReportStatuses, "SaleReportStatusID", "StatusName", saleReport.Status);
            return View(saleReport);
        }

        // POST: SaleReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,ReportDate,GameID,Status")] SaleReport saleReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saleReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "GameID", "HomeClubName", saleReport.GameID);
            ViewBag.Status = new SelectList(db.SaleReportStatuses, "SaleReportStatusID", "StatusName", saleReport.Status);
            return View(saleReport);
        }

        // GET: SaleReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaleReport saleReport = db.SaleReports.Find(id);
            if (saleReport == null)
            {
                return HttpNotFound();
            }
            return View(saleReport);
        }

        // POST: SaleReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SaleReport saleReport = db.SaleReports.Find(id);
            db.SaleReports.Remove(saleReport);
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
