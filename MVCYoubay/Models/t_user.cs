using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MVCYoubay.Models
{
    public partial class t_user : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<t_user> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public t_user()
        {
            this.t_auction = new List<t_auction>();
            this.t_historyofviews = new List<t_historyofviews>();
            this.t_orderandreview = new List<t_orderandreview>();
            this.t_product = new List<t_product>();
            this.t_product1 = new List<t_product>();
        }

        public string USER_TYPE { get; set; }

        //[Key]
        //public int youBayUserId { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string countryOfResidence { get; set; }
        //public string email { get; set; }
        //public string emailActivationToken { get; set; }
        public string firstName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<bool> isBanned { get; set; }
        public string lastName { get; set; }
        //public string phoneNumber { get; set; }
        public Nullable<float> complaintPercentage { get; set; }
        public Nullable<float> gamificationScore { get; set; }
        public string sellerBadges { get; set; }
        public string sellerDescription { get; set; }
        public Nullable<bool> sellerIsSuspiciousFlag { get; set; }
        public string sellerLogo { get; set; }
        public Nullable<float> totalSales { get; set; }
        public Nullable<bool> canAddAdvertisement { get; set; }
        public Nullable<bool> canExportData { get; set; }
        public Nullable<bool> canManageCategories { get; set; }
        public Nullable<bool> canManageManagers { get; set; }
        public Nullable<bool> canModerateSellersAndBuyers { get; set; }
        public Nullable<float> accountBalance { get; set; }
        public string addressCity { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string buyerBadges { get; set; }
        public Nullable<bool> iSMale { get; set; }
        public Nullable<float> totalSpending { get; set; }
        public Nullable<long> customizedAds_customizedAdsId { get; set; }
        public virtual ICollection<t_auction> t_auction { get; set; }
        public virtual t_customizedads t_customizedads { get; set; }
        public virtual ICollection<t_historyofviews> t_historyofviews { get; set; }
        public virtual ICollection<t_orderandreview> t_orderandreview { get; set; }
        public virtual ICollection<t_product> t_product { get; set; }
        public virtual ICollection<t_product> t_product1 { get; set; }


    }
}
