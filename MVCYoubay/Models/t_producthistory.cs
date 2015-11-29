using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_producthistory
    {
        [Key]
        public long productHistoryId { get; set; }
        public Nullable<System.DateTime> historyDate { get; set; }
        public string productImageHistory { get; set; }
        public string productMainDescriptionHistory { get; set; }
        public string productNameHistory { get; set; }
        public string productShortDescriptionHistory { get; set; }
        public Nullable<int> quantityAvailableHistory { get; set; }
        public Nullable<float> sellerPriceHistory { get; set; }
        public string subcategoryAdditionalValuesHistory { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual t_product t_product { get; set; }
    }
}
