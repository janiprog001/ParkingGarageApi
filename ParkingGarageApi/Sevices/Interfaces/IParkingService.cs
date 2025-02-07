using ParkingGarageApi.Models;

namespace ParkolohazAPI.Services.Interfaces
{
    /// <summary>
    /// A parkolóhely kezelést definiáló szolgáltatás interfésze.
    /// </summary>
    public interface IParkingService
    {
        Task<IEnumerable<ParkingSpot>> GetAllSpotsAsync();
        Task<ParkingSpot> UpdateSpotStatusAsync(int spotNumber, string action);
        Task<(int free, int occupied)> GetParkingSummaryAsync();
    }
}
