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
    public class CompileResultsController : BaseController
    {
        // GET: CompileResults
        public async Task<ActionResult> Index()
        {
            return View(await Db.CompileResults.ToListAsync());
        }

        // GET: CompileResults/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompileResult compileResult = await Db.CompileResults.FindAsync(id);
            if (compileResult == null)
            {
                return HttpNotFound();
            }
            return View(compileResult);
        }

        // GET: CompileResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompileResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,IsCompiledSuccesfully,CompiledOn,TimeStamp")] CompileResult compileResult)
        {
            if (ModelState.IsValid)
            {
                Db.CompileResults.Add(compileResult);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(compileResult);
        }

        // GET: CompileResults/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompileResult compileResult = await Db.CompileResults.FindAsync(id);
            if (compileResult == null)
            {
                return HttpNotFound();
            }
            return View(compileResult);
        }

        // POST: CompileResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,IsCompiledSuccesfully,CompiledOn,TimeStamp")] CompileResult compileResult)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(compileResult).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(compileResult);
        }

        // GET: CompileResults/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompileResult compileResult = await Db.CompileResults.FindAsync(id);
            if (compileResult == null)
            {
                return HttpNotFound();
            }
            return View(compileResult);
        }

        // POST: CompileResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CompileResult compileResult = await Db.CompileResults.FindAsync(id);
            Db.CompileResults.Remove(compileResult);
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
