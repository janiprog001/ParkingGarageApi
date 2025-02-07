using Microsoft.EntityFrameworkCore;
using ParkingGarageApi.Models;
using ParkingGarageApi.Data;
using ParkingGarageApi.Models;
using ParkingGarageApi.Services.Interfaces;

namespace ParkolohazAPI.Services
{
    /// <summary>
    /// A parkolóhelyek kezelését megvalósító szolgáltatás.
    /// </summary>
    public class ParkingService : IParkingService
    {
        private readonly ApplicationDbContext _context;

        public ParkingService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Visszaadja az összes parkolóhelyet.
        /// </summary>
        public async Task<IEnumerable<ParkingSpot>> GetAllSpotsAsync()
        {
            return await _context.ParkingSpots.ToListAsync();
        }

        /// <summary>
        /// Frissíti a parkolóhely státuszát a megadott művelet alapján.
        /// </summary>
        public async Task<ParkingSpot> UpdateSpotStatusAsync(int spotNumber, string action)
        {
            var spot = await _context.ParkingSpots.FirstOrDefaultAsync(s => s.SpotNumber == spotNumber);
            if (spot == null)
            {
                throw new Exception("A megadott parkolóhely nem található.");
            }

            // Ha az autó belép, akkor a státusz legyen "Foglalt", kilépés esetén "Szabad".
            if (action.ToLower() == "enter")
            {
                if (spot.Status == "Foglalt")
                    throw new Exception("Ez a parkolóhely már foglalt.");

                spot.Status = "Foglalt";
            }
            else if (action.ToLower() == "exit")
            {
                if (spot.Status == "Szabad")
                    throw new Exception("Ez a parkolóhely már szabad.");

                spot.Status = "Szabad";
            }
            else
            {
                throw new Exception("Érvénytelen művelet. Használható: 'enter' vagy 'exit'.");
            }

            await _context.SaveChangesAsync();
            return spot;
        }

        /// <summary>
        /// Visszaadja a szabad és foglalt parkolóhelyek számát.
        /// </summary>
        public async Task<(int free, int occupied)> GetParkingSummaryAsync()
        {
            int free = await _context.ParkingSpots.CountAsync(s => s.Status == "Szabad");
            int occupied = await _context.ParkingSpots.CountAsync(s => s.Status == "Foglalt");
            return (free, occupied);
        }
    }
}
