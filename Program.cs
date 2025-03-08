using Microsoft.EntityFrameworkCore;
using ParkingGarageApi.Data;
using ParkingGarageApi.Services;
using ParkingGarageApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Konfigur�ld a MySQL adatb�zis kapcsolatot
// A kapcsolati stringet a appsettings.json f�jlban kell defini�lni (p�lda: "DefaultConnection")
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) // �ll�tsd be a megfelel� MySQL verzi�t!
    ));

// Regisztr�ljuk a controller-eket
builder.Services.AddControllers();

// Swagger (OpenAPI) dokument�ci� enged�lyez�se
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Regisztr�ljuk a saj�t szolg�ltat�sainkat
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IParkingService, ParkingService>();

var app = builder.Build();

// Fejleszt�i k�rnyezetben enged�lyezhetj�k a Swagger UI-t
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Itt j�het az autentik�ci�s middleware (pl. JWT) ha sz�ks�ges
app.UseAuthorization();

app.MapControllers();

app.Run();
