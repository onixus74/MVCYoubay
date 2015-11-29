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
    public class t_assistantitemsController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_assistantitems
        public async Task<ActionResult> Index()
        {
            return View(await db.t_assistantitems.ToListAsync());
        }

        // GET: t_assistantitems/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_assistantitems t_assistantitems = await db.t_assistantitems.FindAsync(id);
            if (t_assistantitems == null)
            {
                return HttpNotFound();
            }
            return View(t_assistantitems);
        }

        // GET: t_assistantitems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_assistantitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "assistantItemsId,affirmativeAnswer,affirmativeAnswerQuery,negativeAnswer,negativeAnswerQuery,questionDisplayPriority,questionText,subcategory_subcategoryId")] t_assistantitems t_assistantitems)
        {
            if (ModelState.IsValid)
            {
                db.t_assistantitems.Add(t_assistantitems);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_assistantitems);
        }

        // GET: t_assistantitems/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_assistantitems t_assistantitems = await db.t_assistantitems.FindAsync(id);
            if (t_assistantitems == null)
            {
                return HttpNotFound();
            }
            return View(t_assistantitems);
        }

        // POST: t_assistantitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "assistantItemsId,affirmativeAnswer,affirmativeAnswerQuery,negativeAnswer,negativeAnswerQuery,questionDisplayPriority,questionText,subcategory_subcategoryId")] t_assistantitems t_assistantitems)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_assistantitems).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_assistantitems);
        }

        // GET: t_assistantitems/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_assistantitems t_assistantitems = await db.t_assistantitems.FindAsync(id);
            if (t_assistantitems == null)
            {
                return HttpNotFound();
            }
            return View(t_assistantitems);
        }

        // POST: t_assistantitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_assistantitems t_assistantitems = await db.t_assistantitems.FindAsync(id);
            db.t_assistantitems.Remove(t_assistantitems);
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
