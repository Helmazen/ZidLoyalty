using DAL.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoyaltyEntitiesDBContext : DbContext
    {
        public LoyaltyEntitiesDBContext(DbContextOptions<LoyaltyEntitiesDBContext> options) : base(options)
        {
        }

        public DbSet<PointsCalcType> PointsCalcType { get; set; }
        public DbSet<ConsumePointsIn> ConsumePointsIn { get; set; }
        public DbSet<StoreLoyaltyConfig> StoreLoyaltyConfig { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ConsumePointsIn>()
            //    .HasOne(b => b.ConsumeInStore).WithMany(b=>b.ConsumePointsIns).HasForeignKey("ConsumeInStoreId")                ;

            //modelBuilder.Entity<ConsumePointsIn>()
            //    .Navigation(b => b.ConsumeInStore)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

    }
}
