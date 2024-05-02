using Microsoft.EntityFrameworkCore;
using Samurai.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Repo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Samurais> Samurais { get; set; }
        public DbSet<Kriger> Kriger { get; set; }
        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Viking> Vikings { get; set; }
        public DbSet<War> Wars { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Taste> Taste { get; set; }
        public DbSet<CoffeeTaste> CoffeeTastes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeTaste>()
                .HasKey(ct => new { ct.CoffeeId, ct.TasteId });

            modelBuilder.Entity<CoffeeTaste>()
                .HasOne(ct => ct.Coffee)
                .WithMany(c => c.CoffeeTastes)
                .HasForeignKey(ct => ct.CoffeeId);

            modelBuilder.Entity<CoffeeTaste>()
                .HasOne(ct => ct.Taste)
                .WithMany(t => t.CoffeeTaste)
                .HasForeignKey(ct => ct.TasteId);

        }
    }
}
