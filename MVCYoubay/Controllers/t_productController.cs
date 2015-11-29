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
    public class t_productController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_product
        public async Task<ActionResult> Index()
        {
            return View(await db.t_product.ToListAsync());
        }

        // GET: t_product/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            return View(t_product);
        }

        // GET: t_product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "productId,isDisabledByAdmin,isDisabledBySeller,productDescription,productImage,productName,quantityAvailable,sellerPrice,subcategoryAttributesAndValues,seller_youBayUserId,subcategory_subcategoryId")] t_product t_product)
        {
            if (ModelState.IsValid)
            {
                db.t_product.Add(t_product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_product);
        }

        // GET: t_product/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            return View(t_product);
        }

        // POST: t_product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "productId,isDisabledByAdmin,isDisabledBySeller,productDescription,productImage,productName,quantityAvailable,sellerPrice,subcategoryAttributesAndValues,seller_youBayUserId,subcategory_subcategoryId")] t_product t_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_product);
        }

        // GET: t_product/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_product t_product = await db.t_product.FindAsync(id);
            if (t_product == null)
            {
                return HttpNotFound();
            }
            return View(t_product);
        }

        // POST: t_product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_product t_product = await db.t_product.FindAsync(id);
            db.t_product.Remove(t_product);
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
