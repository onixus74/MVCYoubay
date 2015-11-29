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
    public class t_categoryController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_category
        public async Task<ActionResult> Index()
        {
            return View(await db.t_category.ToListAsync());
        }

        // GET: t_category/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_category t_category = await db.t_category.FindAsync(id);
            if (t_category == null)
            {
                return HttpNotFound();
            }
            return View(t_category);
        }

        // GET: t_category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "categoryId,categoryDisplayPriority,categoryName")] t_category t_category)
        {
            if (ModelState.IsValid)
            {
                db.t_category.Add(t_category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_category);
        }

        // GET: t_category/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_category t_category = await db.t_category.FindAsync(id);
            if (t_category == null)
            {
                return HttpNotFound();
            }
            return View(t_category);
        }

        // POST: t_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "categoryId,categoryDisplayPriority,categoryName")] t_category t_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_category);
        }

        // GET: t_category/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_category t_category = await db.t_category.FindAsync(id);
            if (t_category == null)
            {
                return HttpNotFound();
            }
            return View(t_category);
        }

        // POST: t_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_category t_category = await db.t_category.FindAsync(id);
            db.t_category.Remove(t_category);
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
