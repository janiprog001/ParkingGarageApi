using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ParkingGarageAPI.Entities
{
    public class ParkingHistory
    {
        public int Id { get; set; }
        
        // Parkolási adatok
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string FloorNumber { get; set; }
        public string SpotNumber { get; set; }
        public decimal Fee { get; set; }
        
        // Kapcsolódó autó adatok
        public int CarId { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string LicensePlate { get; set; }
        
        // Kapcsolódó felhasználó adatok
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        
        // Számított tulajdonságok
        [JsonIgnore]
        public TimeSpan Duration => EndTime - StartTime;
        
        public string DurationFormatted => $"{Duration.Hours} óra {Duration.Minutes} perc";
    }
} 