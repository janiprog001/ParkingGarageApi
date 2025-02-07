namespace ParkingGarageApi.DTOs
{
    /// <summary>
    /// Bejelentkezési kérés modellje.
    /// </summary>
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
