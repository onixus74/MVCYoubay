using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCYoubay.Models
{
    public partial class t_product
    {
        public t_product()
        {
            this.t_auction = new List<t_auction>();
            this.t_customizedads = new List<t_customizedads>();
            this.t_historyofviews = new List<t_historyofviews>();
            this.t_orderandreview = new List<t_orderandreview>();
            this.t_producthistory = new List<t_producthistory>();
            this.t_specialpromotion = new List<t_specialpromotion>();
            this.t_user1 = new List<t_user>();
        }
        [Key]
        public long productId { get; set; }
        public Nullable<bool> isDisabledByAdmin { get; set; }
        public Nullable<bool> isDisabledBySeller { get; set; }
        public string productDescription { get; set; }
        public string productImage { get; set; }
        public string productName { get; set; }
        public Nullable<int> quantityAvailable { get; set; }
        public Nullable<float> sellerPrice { get; set; }
        public string subcategoryAttributesAndValues { get; set; }
        public Nullable<long> seller_youBayUserId { get; set; }
        public Nullable<long> subcategory_subcategoryId { get; set; }
        public virtual ICollection<t_auction> t_auction { get; set; }
        public virtual ICollection<t_customizedads> t_customizedads { get; set; }
        public virtual ICollection<t_historyofviews> t_historyofviews { get; set; }
        public virtual ICollection<t_orderandreview> t_orderandreview { get; set; }
        public virtual ICollection<t_producthistory> t_producthistory { get; set; }
        public virtual t_subcategory t_subcategory { get; set; }
        public virtual t_user t_user { get; set; }
        public virtual ICollection<t_specialpromotion> t_specialpromotion { get; set; }
        public virtual ICollection<t_user> t_user1 { get; set; }
    }
}
