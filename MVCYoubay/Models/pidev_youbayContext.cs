using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCYoubay.Models
{
    public class pidev_youbayContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public pidev_youbayContext() : base("name=pidev_youbayContext")
        {
        }

        public System.Data.Entity.DbSet<Data.Models.t_assistantitems> t_assistantitems { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_auction> t_auction { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_category> t_category { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_customizedads> t_customizedads { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_historyofviews> t_historyofviews { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_product> t_product { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_orderandreview> t_orderandreview { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_producthistory> t_producthistory { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_specialpromotion> t_specialpromotion { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_subcategory> t_subcategory { get; set; }

        public System.Data.Entity.DbSet<Data.Models.t_user> t_user { get; set; }
    }
}
