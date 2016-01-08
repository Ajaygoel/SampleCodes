using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineCoding.Dal.Contexts;
using OnlineCoding.Domain.Entities;

namespace OnlineCoding.WebManagement.Controllers
{
    public class TestResultsController : BaseController
    {   
        // GET: TestResults
        public async Task<ActionResult> Index()
        {
            return View(await Db.TestResults.ToListAsync());
        }

        // GET: TestResults/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestResult testResult = await Db.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return HttpNotFound();
            }
            return View(testResult);
        }

        // GET: TestResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TestResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,IsSuccessful,ResultDescription,TimeStamp")] TestResult testResult)
        {
            if (ModelState.IsValid)
            {
                Db.TestResults.Add(testResult);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(testResult);
        }

        // GET: TestResults/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestResult testResult = await Db.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return HttpNotFound();
            }
            return View(testResult);
        }

        // POST: TestResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,IsSuccessful,ResultDescription,TimeStamp")] TestResult testResult)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(testResult).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(testResult);
        }

        // GET: TestResults/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TestResult testResult = await Db.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return HttpNotFound();
            }
            return View(testResult);
        }

        // POST: TestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            TestResult testResult = await Db.TestResults.FindAsync(id);
            Db.TestResults.Remove(testResult);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
