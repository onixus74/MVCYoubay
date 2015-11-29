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
    public class t_auctionController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_auction
        public async Task<ActionResult> Index()
        {
            return View(await db.t_auction.ToListAsync());
        }

        // GET: t_auction/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_auction t_auction = await db.t_auction.FindAsync(id);
            if (t_auction == null)
            {
                return HttpNotFound();
            }
            return View(t_auction);
        }

        // GET: t_auction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_auction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "auctionId,currentPrice,endTime,startTime,buyer_youBayUserId,product_productId")] t_auction t_auction)
        {
            if (ModelState.IsValid)
            {
                db.t_auction.Add(t_auction);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_auction);
        }

        // GET: t_auction/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_auction t_auction = await db.t_auction.FindAsync(id);
            if (t_auction == null)
            {
                return HttpNotFound();
            }
            return View(t_auction);
        }

        // POST: t_auction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "auctionId,currentPrice,endTime,startTime,buyer_youBayUserId,product_productId")] t_auction t_auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_auction).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_auction);
        }

        // GET: t_auction/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_auction t_auction = await db.t_auction.FindAsync(id);
            if (t_auction == null)
            {
                return HttpNotFound();
            }
            return View(t_auction);
        }

        // POST: t_auction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_auction t_auction = await db.t_auction.FindAsync(id);
            db.t_auction.Remove(t_auction);
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
