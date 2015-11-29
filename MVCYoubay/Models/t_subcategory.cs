using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public partial class t_subcategory
    {
        public t_subcategory()
        {
            this.t_assistantitems = new List<t_assistantitems>();
            this.t_product = new List<t_product>();
        }

        [Key]
        public long subcategoryId { get; set; }
        public string assistantAvatarImage { get; set; }
        public Nullable<int> categoryDisplayPriority { get; set; }
        public string categoryName { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string subcategoryAttributesAndTypes { get; set; }
        public Nullable<long> category_categoryId { get; set; }
        public virtual ICollection<t_assistantitems> t_assistantitems { get; set; }
        public virtual t_category t_category { get; set; }
        public virtual ICollection<t_product> t_product { get; set; }
    }
}
