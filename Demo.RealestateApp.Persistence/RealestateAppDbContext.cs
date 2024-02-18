using Demo.RealestateApp.Domain.Common;
using Demo.RealestateApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.RealestateApp.Persistence
{
    public class RealestateAppDbContext : DbContext
    {
        public RealestateAppDbContext(DbContextOptions<RealestateAppDbContext> options) : base(options)
        {
        }

        public DbSet<Property> properties { get; set; }
        public DbSet<Building> buildings { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<Image> images { get; set; }
        public DbSet<Address> addresses { get; set; }
        public DbSet<OrderProduct>  orderProducts { get; set; }




        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
