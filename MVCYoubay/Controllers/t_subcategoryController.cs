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
    public class t_subcategoryController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_subcategory
        public async Task<ActionResult> Index()
        {
            return View(await db.t_subcategory.ToListAsync());
        }

        // GET: t_subcategory/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // GET: t_subcategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_subcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "subcategoryId,assistantAvatarImage,categoryDisplayPriority,categoryName,isActive,subcategoryAttributesAndTypes,category_categoryId")] t_subcategory t_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.t_subcategory.Add(t_subcategory);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_subcategory);
        }

        // GET: t_subcategory/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // POST: t_subcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "subcategoryId,assistantAvatarImage,categoryDisplayPriority,categoryName,isActive,subcategoryAttributesAndTypes,category_categoryId")] t_subcategory t_subcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_subcategory).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_subcategory);
        }

        // GET: t_subcategory/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            if (t_subcategory == null)
            {
                return HttpNotFound();
            }
            return View(t_subcategory);
        }

        // POST: t_subcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_subcategory t_subcategory = await db.t_subcategory.FindAsync(id);
            db.t_subcategory.Remove(t_subcategory);
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
