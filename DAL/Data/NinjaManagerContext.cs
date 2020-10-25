using System;
using System.Linq;
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

        public NinjaManagerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [START NINJA - ARMOUR MANY TO MANY]
            modelBuilder.Entity<NinjaArmour>()
                .HasKey(na => new { na.NinjaId, na.ArmourId });

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

        public static void InsertTestData(NinjaManagerContext context)
        {
            // Do not run if database is not empty
            if (context.Armour.Any() || context.Ninja.Any() || context.NinjaArmour.Any())
            {
                return;
            }


            // Remove old data (not recommended for larger databases
            context.Armour.RemoveRange(context.Armour);
            context.Ninja.RemoveRange(context.Ninja);
            context.NinjaArmour.RemoveRange(context.NinjaArmour);

            context.Ninja.Add(new Ninja
            {
                Gold = 200000,
                Name = "Rogier met 1 nier"
            });
            context.Ninja.Add(new Ninja
            {
                Gold = 30,
                Name = "Peter van hiernaast"
            });

            context.Ninja.Add(new Ninja
            {
                Gold = 900,
                Name = "Rijke Roland"
            });

            context.SaveChanges();

            var rnd = new Random();
            foreach (var armourType in (ArmourEnum[])Enum.GetValues(typeof(ArmourEnum)))
            {
                for (var j = 0; j < 3; j++)
                {
                    context.Armour.Add(
                        new Armour
                        {
                            Agility = rnd.Next(-5, 5),
                            ArmourType = armourType,
                            Intelligence = rnd.Next(-5, 5),
                            Name = armourType + " No. " + j,
                            Price = rnd.Next(1, 20),
                            Strength = rnd.Next(-5, 5),
                        }
                    );
                }
            }

            context.SaveChanges();
        }
    }
}