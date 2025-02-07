using ParkingGarageApi.Models;
using ParkingGarageApi.DTOs;

namespace ParkingGarageApi.Services.Interfaces
{
    /// <summary>
    /// A felhasználói műveleteket definiáló szolgáltatás interfésze.
    /// </summary>
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterRequest request);
        Task<User> LoginAsync(LoginRequest request);
        Task LoginAsync(Microsoft.AspNetCore.Identity.Data.LoginRequest request);
    }
}
