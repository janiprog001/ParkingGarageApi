using Microsoft.EntityFrameworkCore;
using ParkingGarageApi.Data;
using ParkingGarageApi.Services;
using ParkingGarageApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Konfiguráld a MySQL adatbázis kapcsolatot
// A kapcsolati stringet a appsettings.json fájlban kell definiálni (példa: "DefaultConnection")
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) // Állítsd be a megfelelõ MySQL verziót!
    ));

// Regisztráljuk a controller-eket
builder.Services.AddControllers();

// Swagger (OpenAPI) dokumentáció engedélyezése
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Regisztráljuk a saját szolgáltatásainkat
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IParkingService, ParkingService>();

var app = builder.Build();

// Fejlesztõi környezetben engedélyezhetjük a Swagger UI-t
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Itt jöhet az autentikációs middleware (pl. JWT) ha szükséges
app.UseAuthorization();

app.MapControllers();

app.Run();
