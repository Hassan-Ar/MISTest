using Demo.RealestateApp.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Identity
{
    public class RealestateappIdentityDbContext : IdentityDbContext<ApplicationUser>
    {

        public RealestateappIdentityDbContext()
        {
                
        }
        public RealestateappIdentityDbContext(DbContextOptions<RealestateappIdentityDbContext> options) :base(options) 
        {
            

        }
        
    }
}
