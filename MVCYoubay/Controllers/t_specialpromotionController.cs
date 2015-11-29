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
    public class t_specialpromotionController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_specialpromotion
        public async Task<ActionResult> Index()
        {
            return View(await db.t_specialpromotion.ToListAsync());
        }

        // GET: t_specialpromotion/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_specialpromotion t_specialpromotion = await db.t_specialpromotion.FindAsync(id);
            if (t_specialpromotion == null)
            {
                return HttpNotFound();
            }
            return View(t_specialpromotion);
        }

        // GET: t_specialpromotion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_specialpromotion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "specialPromotionId,dealDescription,dealDisabledByAdmin,endDate,reductionPercentage,startDate,product_productId")] t_specialpromotion t_specialpromotion)
        {
            if (ModelState.IsValid)
            {
                db.t_specialpromotion.Add(t_specialpromotion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_specialpromotion);
        }

        // GET: t_specialpromotion/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_specialpromotion t_specialpromotion = await db.t_specialpromotion.FindAsync(id);
            if (t_specialpromotion == null)
            {
                return HttpNotFound();
            }
            return View(t_specialpromotion);
        }

        // POST: t_specialpromotion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "specialPromotionId,dealDescription,dealDisabledByAdmin,endDate,reductionPercentage,startDate,product_productId")] t_specialpromotion t_specialpromotion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_specialpromotion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_specialpromotion);
        }

        // GET: t_specialpromotion/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_specialpromotion t_specialpromotion = await db.t_specialpromotion.FindAsync(id);
            if (t_specialpromotion == null)
            {
                return HttpNotFound();
            }
            return View(t_specialpromotion);
        }

        // POST: t_specialpromotion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_specialpromotion t_specialpromotion = await db.t_specialpromotion.FindAsync(id);
            db.t_specialpromotion.Remove(t_specialpromotion);
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
