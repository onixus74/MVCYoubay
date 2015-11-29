using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data.Models;
using MVCYoubay.Models;

namespace MVCYoubay.Controllers
{
    public class t_historyofviewsController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_historyofviews
        public async Task<ActionResult> Index()
        {
            var t_historyofviews = db.t_historyofviews.Include(t => t.t_product);
            return View(await t_historyofviews.ToListAsync());
        }

        // GET: t_historyofviews/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_historyofviews t_historyofviews = await db.t_historyofviews.FindAsync(id);
            if (t_historyofviews == null)
            {
                return HttpNotFound();
            }
            return View(t_historyofviews);
        }

        // GET: t_historyofviews/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription");
            return View();
        }

        // POST: t_historyofviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "buyerId,productId,theDate,client,comment")] t_historyofviews t_historyofviews)
        {
            if (ModelState.IsValid)
            {
                db.t_historyofviews.Add(t_historyofviews);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_historyofviews.productId);
            return View(t_historyofviews);
        }

        // GET: t_historyofviews/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_historyofviews t_historyofviews = await db.t_historyofviews.FindAsync(id);
            if (t_historyofviews == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_historyofviews.productId);
            return View(t_historyofviews);
        }

        // POST: t_historyofviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "buyerId,productId,theDate,client,comment")] t_historyofviews t_historyofviews)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_historyofviews).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_historyofviews.productId);
            return View(t_historyofviews);
        }

        // GET: t_historyofviews/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_historyofviews t_historyofviews = await db.t_historyofviews.FindAsync(id);
            if (t_historyofviews == null)
            {
                return HttpNotFound();
            }
            return View(t_historyofviews);
        }

        // POST: t_historyofviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_historyofviews t_historyofviews = await db.t_historyofviews.FindAsync(id);
            db.t_historyofviews.Remove(t_historyofviews);
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
