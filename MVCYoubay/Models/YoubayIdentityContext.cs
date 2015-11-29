using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCYoubay.Models
{
    public class YoubayIdentityContext : IdentityDbContext<t_user>
    {
        public YoubayIdentityContext()
            : base("IdentityConnection")
        {
    }

    public static YoubayIdentityContext Create()
    {
        return new YoubayIdentityContext();
    }
    }

}