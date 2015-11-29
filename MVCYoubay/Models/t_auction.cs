using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_auction
    {
        [Key]
        public long auctionId { get; set; }
        public Nullable<float> currentPrice { get; set; }
        public Nullable<System.DateTime> endTime { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public Nullable<long> buyer_youBayUserId { get; set; }
        public Nullable<long> product_productId { get; set; }
        public virtual t_product t_product { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
