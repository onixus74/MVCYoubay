using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCYoubay.Models;

namespace MVCYoubay.Controllers
{
    public class t_orderandreviewController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_orderandreview
        public async Task<ActionResult> Index()
        {
            var t_orderandreview = db.t_orderandreview.Include(t => t.t_product);
            return View(await t_orderandreview.ToListAsync());
        }

        // GET: t_orderandreview/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_orderandreview t_orderandreview = await db.t_orderandreview.FindAsync(id);
            if (t_orderandreview == null)
            {
                return HttpNotFound();
            }
            return View(t_orderandreview);
        }

        // GET: t_orderandreview/Create
        public ActionResult Create()
        {
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription");
            return View();
        }

        // POST: t_orderandreview/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "buyerId,productId,theDate,buyerHasLeftAReview,hasFiledComplaint,initialMessageToSeller,oderFulfilledBySeller,orderDeliveredToBuyer,pricePaidByBuyer,productRating,reviewText,reviewTitle")] t_orderandreview t_orderandreview)
        {
            if (ModelState.IsValid)
            {
                db.t_orderandreview.Add(t_orderandreview);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_orderandreview.productId);
            return View(t_orderandreview);
        }

        // GET: t_orderandreview/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_orderandreview t_orderandreview = await db.t_orderandreview.FindAsync(id);
            if (t_orderandreview == null)
            {
                return HttpNotFound();
            }
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_orderandreview.productId);
            return View(t_orderandreview);
        }

        // POST: t_orderandreview/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "buyerId,productId,theDate,buyerHasLeftAReview,hasFiledComplaint,initialMessageToSeller,oderFulfilledBySeller,orderDeliveredToBuyer,pricePaidByBuyer,productRating,reviewText,reviewTitle")] t_orderandreview t_orderandreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_orderandreview).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.productId = new SelectList(db.t_product, "productId", "productDescription", t_orderandreview.productId);
            return View(t_orderandreview);
        }

        // GET: t_orderandreview/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_orderandreview t_orderandreview = await db.t_orderandreview.FindAsync(id);
            if (t_orderandreview == null)
            {
                return HttpNotFound();
            }
            return View(t_orderandreview);
        }

        // POST: t_orderandreview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_orderandreview t_orderandreview = await db.t_orderandreview.FindAsync(id);
            db.t_orderandreview.Remove(t_orderandreview);
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
