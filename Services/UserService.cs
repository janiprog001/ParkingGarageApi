using Microsoft.EntityFrameworkCore;
using ParkingGarageApi.Models;
using ParkingGarageApi.Data;
using ParkingGarageApi.DTOs;
using ParkingGarageApi.Services.Interfaces;

namespace ParkingGarageApi.Services
{
    /// <summary>
    /// A felhasználói regisztrációt és bejelentkezést kezelő szolgáltatás.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Regisztrál egy új felhasználót.
        /// </summary>
        public async Task<User> RegisterAsync(RegisterRequest request)
        {
            // Ellenőrizzük, hogy létezik-e már az adott felhasználónév vagy email
            if (await _context.Users.AnyAsync(u => u.UserName == request.UserName || u.Email == request.Email))
            {
                throw new Exception("A felhasználó már létezik.");
            }

            var user = new User
            {
                UserName = request.UserName,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password, // Éles környezetben hash-eld a jelszót!
                Phone = request.Phone,
                LicensePlate = request.LicensePlate
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        /// <summary>
        /// Bejelentkezik egy felhasználóval.
        /// </summary>
        public async Task<User> LoginAsync(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u =>
                u.UserName == request.UserName && u.Password == request.Password);
            if (user == null)
            {
                throw new Exception("Érvénytelen felhasználónév vagy jelszó.");
            }
            return user;
        }

        public Task LoginAsync(Microsoft.AspNetCore.Identity.Data.LoginRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
