namespace ParkingGarageApi.DTOs
{
 /// <summary>
 /// Parkoló művelet (belépés/kilépés) kérés modellje.
 /// </summary>
    public class ParkingActionRequest
    {
        // A parkolóhely sorszáma, amelyen a művelet történik
        public int SpotNumber { get; set; }

        // A művelet típusa: "enter" (belépés) vagy "exit" (kilépés)
        public string Action { get; set; }
    }
}
