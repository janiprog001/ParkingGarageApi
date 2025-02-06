using Microsoft.AspNetCore.Mvc;
using ParkolohazAPI.DTOs;
using ParkolohazAPI.Services.Interfaces;

namespace ParkolohazAPI.Controllers
{
    /// <summary>
    /// A parkolóhelyek kezelését megvalósító API controller.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly IParkingService _parkingService;

        public ParkingController(IParkingService parkingService)
        {
            _parkingService = parkingService;
        }

        /// <summary>
        /// Visszaadja az összes parkolóhely állapotát.
        /// </summary>
        [HttpGet("spots")]
        public async Task<IActionResult> GetAllSpots()
        {
            var spots = await _parkingService.GetAllSpotsAsync();
            return Ok(spots);
        }

        /// <summary>
        /// Frissíti a parkolóhely státuszát (belépés vagy kilépés).
        /// </summary>
        [HttpPut("update")]
        public async Task<IActionResult> UpdateSpotStatus([FromBody] ParkingActionRequest request)
        {
            try
            {
                var updatedSpot = await _parkingService.UpdateSpotStatusAsync(request.SpotNumber, request.Action);
                return Ok(new { message = "Parkolóhely frissítve", spot = updatedSpot });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        /// <summary>
        /// Visszaadja a szabad és foglalt parkolóhelyek számát.
        /// </summary>
        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary()
        {
            var summary = await _parkingService.GetParkingSummaryAsync();
            return Ok(new { free = summary.free, occupied = summary.occupied });
        }
    }
}
