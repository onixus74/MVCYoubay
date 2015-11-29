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
    public class t_userController : Controller
    {
        private pidev_youbayContext db = new pidev_youbayContext();

        // GET: t_user
        public async Task<ActionResult> Index()
        {
            return View(await db.t_user.ToListAsync());
        }

        // GET: t_user/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_user t_user = await db.t_user.FindAsync(id);
            if (t_user == null)
            {
                return HttpNotFound();
            }
            return View(t_user);
        }

        // GET: t_user/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: t_user/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "youBayUserId,USER_TYPE,birthday,countryOfResidence,email,emailActivationToken,firstName,isActive,isBanned,lastName,phoneNumber,complaintPercentage,gamificationScore,sellerBadges,sellerDescription,sellerIsSuspiciousFlag,sellerLogo,totalSales,canAddAdvertisement,canExportData,canManageCategories,canManageManagers,canModerateSellersAndBuyers,accountBalance,addressCity,addressLine1,addressLine2,buyerBadges,iSMale,totalSpending,customizedAds_customizedAdsId")] t_user t_user)
        {
            if (ModelState.IsValid)
            {
                db.t_user.Add(t_user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(t_user);
        }

        // GET: t_user/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_user t_user = await db.t_user.FindAsync(id);
            if (t_user == null)
            {
                return HttpNotFound();
            }
            return View(t_user);
        }

        // POST: t_user/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "youBayUserId,USER_TYPE,birthday,countryOfResidence,email,emailActivationToken,firstName,isActive,isBanned,lastName,phoneNumber,complaintPercentage,gamificationScore,sellerBadges,sellerDescription,sellerIsSuspiciousFlag,sellerLogo,totalSales,canAddAdvertisement,canExportData,canManageCategories,canManageManagers,canModerateSellersAndBuyers,accountBalance,addressCity,addressLine1,addressLine2,buyerBadges,iSMale,totalSpending,customizedAds_customizedAdsId")] t_user t_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(t_user);
        }

        // GET: t_user/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            t_user t_user = await db.t_user.FindAsync(id);
            if (t_user == null)
            {
                return HttpNotFound();
            }
            return View(t_user);
        }

        // POST: t_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            t_user t_user = await db.t_user.FindAsync(id);
            db.t_user.Remove(t_user);
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
