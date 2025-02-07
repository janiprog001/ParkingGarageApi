namespace ParkingGarageApi.Models
{
    /// <summary>
    /// A parkolóhely adatait tartalmazó modell.
    /// </summary>
    public class ParkingSpot
    {
        public int Id { get; set; }

        // A parkolóhely sorszáma (1-100)
        public int SpotNumber { get; set; }

        // A parkolóhely státusza: "Szabad" vagy "Foglalt"
        public string Status { get; set; }
    }
}
