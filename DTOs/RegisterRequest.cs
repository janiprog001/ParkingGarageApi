namespace ParkingGarageApi.DTOs

    {
        /// <summary>
        /// Regisztrációs kérés modellje.
        /// </summary>
        public class RegisterRequest
        {
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Phone { get; set; }
            public string LicensePlate { get; set; }
        }
    }
