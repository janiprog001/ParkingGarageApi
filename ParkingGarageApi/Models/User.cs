namespace ParkolohazAPI.Models
{
    /// <summary>
    /// A felhasználó adatait tartalmazó modell.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        // Egyedi felhasználónév
        public string UserName { get; set; }

        // Teljes név
        public string FullName { get; set; }

        // Egyedi email cím
        public string Email { get; set; }

        // Jelszó (éles környezetben javasolt hash-elni)
        public string Password { get; set; }

        // Telefonszám
        public string Phone { get; set; }

        // Rendszám (autó azonosításához)
        public string LicensePlate { get; set; }
    }
}
