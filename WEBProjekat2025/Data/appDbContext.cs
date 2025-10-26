

using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WEBProjekat2025.Models;

namespace WEBProjekat2025.NewFolder2
{
    public class appDbContext:DbContext
    {

        public appDbContext(DbContextOptions<appDbContext> Opcije): base(Opcije)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arome_Pice>().HasKey(ap => new
            {
                ap.AromaId,
                ap.PiceId
            });

            modelBuilder.Entity<Arome_Pice>().HasOne(p => p.Pice).WithMany(ap => ap.Arome_Pice).HasForeignKey(p => p.PiceId);
            modelBuilder.Entity<Arome_Pice>().HasOne(p => p.Aroma).WithMany(ap => ap.Arome_Pice).HasForeignKey(p => p.AromaId);


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Arome_Pice> Arome_Pice { get; set; }
        public DbSet<Aroma> Aroma { get; set; }
        public DbSet<Pice> Pice { get; set; }
        public DbSet<Diskont> Diskont { get; set; }
        public DbSet<Proizvodjac> Proizvodjac { get; set; }

        //orders relate tables

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }

    

}
