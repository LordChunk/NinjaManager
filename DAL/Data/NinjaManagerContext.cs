using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class NinjaManagerContext : DbContext
    {
        // DbSets
        public DbSet<Ninja> Ninja { get; set; }
        public DbSet<Armour> Armour { get; set; }
        public DbSet<NinjaArmour> NinjaArmour { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NinjaManager;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [START NINJA - ARMOUR MANY TO MANY]
            modelBuilder.Entity<NinjaArmour>()
                .HasKey(na => new { na.NinjaId, na.ArmourId});

            // Set 0 to m relationship with NinjaArmour - Armour
            modelBuilder.Entity<NinjaArmour>()
                .HasOne(na => na.Armour)
                .WithMany(a => a.UsedBy)
                .HasForeignKey(na => na.ArmourId);

            // Set 0 to m relationship with NinjaArmour - Ninja
            modelBuilder.Entity<NinjaArmour>()
                .HasOne(na => na.Ninja)
                .WithMany(n => n.EquippedArmour)
                .HasForeignKey(na => na.NinjaId);
            // [END NINJA - ARMOUR MANY TO MANY]
        }
    }
}