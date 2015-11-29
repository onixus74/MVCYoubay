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
    public class t_producthistoryController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_producthistory
        public async Task<ActionResult> Index()
        {
            return View(await db.t_producthistory.ToListAsync());
        }

        // GET: t_producthistory/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_producthistory t_producthistory = await db.t_producthistory.FindAsync(id);
            if (t_producthistory == null)
            {
                return HttpNotFound();
            }
            return View(t_producthistory);
        }

        // GET: t_producthistory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_producthistory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productHistoryId,historyDate,productImageHistory,productMainDescriptionHistory,productNameHistory,productShortDescriptionHistory,quantityAvailableHistory,sellerPriceHistory,subcategoryAdditionalValuesHistory,product_productId")] t_producthistory t_producthistory)
        {
            if (ModelState.IsValid)
            {
                db.t_producthistory.Add(t_producthistory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_producthistory);
        }

        // GET: t_producthistory/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_producthistory t_producthistory = await db.t_producthistory.FindAsync(id);
            if (t_producthistory == null)
            {
                return HttpNotFound();
            }
            return View(t_producthistory);
        }

        // POST: t_producthistory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productHistoryId,historyDate,productImageHistory,productMainDescriptionHistory,productNameHistory,productShortDescriptionHistory,quantityAvailableHistory,sellerPriceHistory,subcategoryAdditionalValuesHistory,product_productId")] t_producthistory t_producthistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_producthistory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_producthistory);
        }

        // GET: t_producthistory/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_producthistory t_producthistory = await db.t_producthistory.FindAsync(id);
            if (t_producthistory == null)
            {
                return HttpNotFound();
            }
            return View(t_producthistory);
        }

        // POST: t_producthistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_producthistory t_producthistory = await db.t_producthistory.FindAsync(id);
            db.t_producthistory.Remove(t_producthistory);
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
