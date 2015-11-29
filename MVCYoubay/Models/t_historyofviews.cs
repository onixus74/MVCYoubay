using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCYoubay.Models
{
    public partial class t_historyofviews
    {
        [Key][Column(Order = 0)]
        public long buyerId { get; set; }
        [Key][Column(Order = 1)]
        public long productId { get; set; }
        public System.DateTime theDate { get; set; }
        public Nullable<int> client { get; set; }
        public string comment { get; set; }
        public virtual t_product t_product { get; set; }
        public virtual t_user t_user { get; set; }
    }
}
