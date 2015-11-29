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
    public class t_customizedadsController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_customizedads
        public async Task<ActionResult> Index()
        {
            return View(await db.t_customizedads.ToListAsync());
        }

        // GET: t_customizedads/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_customizedads t_customizedads = await db.t_customizedads.FindAsync(id);
            if (t_customizedads == null)
            {
                return HttpNotFound();
            }
            return View(t_customizedads);
        }

        // GET: t_customizedads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_customizedads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "customizedAdsId,customizedMessage,endDate,importanceScore,isACustomizedMarketingAd,isAPurchasedAd,startDate,product_productId")] t_customizedads t_customizedads)
        {
            if (ModelState.IsValid)
            {
                db.t_customizedads.Add(t_customizedads);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_customizedads);
        }

        // GET: t_customizedads/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_customizedads t_customizedads = await db.t_customizedads.FindAsync(id);
            if (t_customizedads == null)
            {
                return HttpNotFound();
            }
            return View(t_customizedads);
        }

        // POST: t_customizedads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "customizedAdsId,customizedMessage,endDate,importanceScore,isACustomizedMarketingAd,isAPurchasedAd,startDate,product_productId")] t_customizedads t_customizedads)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_customizedads).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_customizedads);
        }

        // GET: t_customizedads/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_customizedads t_customizedads = await db.t_customizedads.FindAsync(id);
            if (t_customizedads == null)
            {
                return HttpNotFound();
            }
            return View(t_customizedads);
        }

        // POST: t_customizedads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_customizedads t_customizedads = await db.t_customizedads.FindAsync(id);
            db.t_customizedads.Remove(t_customizedads);
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
