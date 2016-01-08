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
    public class CompilerClientsController : BaseController
    {
        
        // GET: CompilerClients
        public async Task<ActionResult> Index()
        {
            return View(await Db.CompilerClients.ToListAsync());
        }

        // GET: CompilerClients/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompilerClient compilerClient = await Db.CompilerClients.FindAsync(id);
            if (compilerClient == null)
            {
                return HttpNotFound();
            }
            return View(compilerClient);
        }

        // GET: CompilerClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompilerClients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClientName,ClientIpAddress,ConnectedOn,DisconnectedOn,IsConnected,TimeStamp")] CompilerClient compilerClient)
        {
            if (ModelState.IsValid)
            {
                Db.CompilerClients.Add(compilerClient);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(compilerClient);
        }

        // GET: CompilerClients/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompilerClient compilerClient = await Db.CompilerClients.FindAsync(id);
            if (compilerClient == null)
            {
                return HttpNotFound();
            }
            return View(compilerClient);
        }

        // POST: CompilerClients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClientName,ClientIpAddress,ConnectedOn,DisconnectedOn,IsConnected,TimeStamp")] CompilerClient compilerClient)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(compilerClient).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(compilerClient);
        }

        // GET: CompilerClients/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompilerClient compilerClient = await Db.CompilerClients.FindAsync(id);
            if (compilerClient == null)
            {
                return HttpNotFound();
            }
            return View(compilerClient);
        }

        // POST: CompilerClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CompilerClient compilerClient = await Db.CompilerClients.FindAsync(id);
            Db.CompilerClients.Remove(compilerClient);
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
