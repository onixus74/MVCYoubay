using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_customizedads
    {
        public t_customizedads()
        {
            this.t_user = new List<t_user>();
        }
        [Key]
        public long customizedAdsId { get; set; }
        public string customizedMessage { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
        public Nullable<float> importanceScore { get; set; }
        public Nullable<bool> isACustomizedMarketingAd { get; set; }
        public Nullable<bool> isAPurchasedAd { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual t_product t_product { get; set; }
        public virtual ICollection<t_user> t_user { get; set; }
    }
}
