using Microsoft.EntityFrameworkCore;
using ParkolohazAPI.Models;

namespace ParkolohazAPI.Data
{
    /// <summary>
    /// Az adatbázis kontextus, amely az Entity Framework Core segítségével kezeli az adatbázis műveleteket.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        // Felhasználók táblája
        public DbSet<User> Users { get; set; }

        // Parkolóhelyek táblája
        public DbSet<ParkingSpot> ParkingSpots { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Adatbázis struktúra és seed adatok konfigurálása.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguráljuk az egyedi kulcsokat és indexeket a Users táblán
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            // Parkolóhelyek tábla konfigurációja
            modelBuilder.Entity<ParkingSpot>()
                .HasKey(p => p.Id);

            // Seedeljük a 100 parkolóhelyet (alapértelmezetten "Szabad" státusszal)
            List<ParkingSpot> spots = new();
            for (int i = 1; i <= 100; i++)
            {
                spots.Add(new ParkingSpot
                {
                    Id = i,
                    SpotNumber = i,
                    Status = "Szabad"
                });
            }
            modelBuilder.Entity<ParkingSpot>().HasData(spots);
        }
    }
}
