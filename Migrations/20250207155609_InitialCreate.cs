using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParkingGarageApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpotNumber = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FullName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LicensePlate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "Id", "SpotNumber", "Status" },
                values: new object[,]
                {
                    { 1, 1, "Szabad" },
                    { 2, 2, "Szabad" },
                    { 3, 3, "Szabad" },
                    { 4, 4, "Szabad" },
                    { 5, 5, "Szabad" },
                    { 6, 6, "Szabad" },
                    { 7, 7, "Szabad" },
                    { 8, 8, "Szabad" },
                    { 9, 9, "Szabad" },
                    { 10, 10, "Szabad" },
                    { 11, 11, "Szabad" },
                    { 12, 12, "Szabad" },
                    { 13, 13, "Szabad" },
                    { 14, 14, "Szabad" },
                    { 15, 15, "Szabad" },
                    { 16, 16, "Szabad" },
                    { 17, 17, "Szabad" },
                    { 18, 18, "Szabad" },
                    { 19, 19, "Szabad" },
                    { 20, 20, "Szabad" },
                    { 21, 21, "Szabad" },
                    { 22, 22, "Szabad" },
                    { 23, 23, "Szabad" },
                    { 24, 24, "Szabad" },
                    { 25, 25, "Szabad" },
                    { 26, 26, "Szabad" },
                    { 27, 27, "Szabad" },
                    { 28, 28, "Szabad" },
                    { 29, 29, "Szabad" },
                    { 30, 30, "Szabad" },
                    { 31, 31, "Szabad" },
                    { 32, 32, "Szabad" },
                    { 33, 33, "Szabad" },
                    { 34, 34, "Szabad" },
                    { 35, 35, "Szabad" },
                    { 36, 36, "Szabad" },
                    { 37, 37, "Szabad" },
                    { 38, 38, "Szabad" },
                    { 39, 39, "Szabad" },
                    { 40, 40, "Szabad" },
                    { 41, 41, "Szabad" },
                    { 42, 42, "Szabad" },
                    { 43, 43, "Szabad" },
                    { 44, 44, "Szabad" },
                    { 45, 45, "Szabad" },
                    { 46, 46, "Szabad" },
                    { 47, 47, "Szabad" },
                    { 48, 48, "Szabad" },
                    { 49, 49, "Szabad" },
                    { 50, 50, "Szabad" },
                    { 51, 51, "Szabad" },
                    { 52, 52, "Szabad" },
                    { 53, 53, "Szabad" },
                    { 54, 54, "Szabad" },
                    { 55, 55, "Szabad" },
                    { 56, 56, "Szabad" },
                    { 57, 57, "Szabad" },
                    { 58, 58, "Szabad" },
                    { 59, 59, "Szabad" },
                    { 60, 60, "Szabad" },
                    { 61, 61, "Szabad" },
                    { 62, 62, "Szabad" },
                    { 63, 63, "Szabad" },
                    { 64, 64, "Szabad" },
                    { 65, 65, "Szabad" },
                    { 66, 66, "Szabad" },
                    { 67, 67, "Szabad" },
                    { 68, 68, "Szabad" },
                    { 69, 69, "Szabad" },
                    { 70, 70, "Szabad" },
                    { 71, 71, "Szabad" },
                    { 72, 72, "Szabad" },
                    { 73, 73, "Szabad" },
                    { 74, 74, "Szabad" },
                    { 75, 75, "Szabad" },
                    { 76, 76, "Szabad" },
                    { 77, 77, "Szabad" },
                    { 78, 78, "Szabad" },
                    { 79, 79, "Szabad" },
                    { 80, 80, "Szabad" },
                    { 81, 81, "Szabad" },
                    { 82, 82, "Szabad" },
                    { 83, 83, "Szabad" },
                    { 84, 84, "Szabad" },
                    { 85, 85, "Szabad" },
                    { 86, 86, "Szabad" },
                    { 87, 87, "Szabad" },
                    { 88, 88, "Szabad" },
                    { 89, 89, "Szabad" },
                    { 90, 90, "Szabad" },
                    { 91, 91, "Szabad" },
                    { 92, 92, "Szabad" },
                    { 93, 93, "Szabad" },
                    { 94, 94, "Szabad" },
                    { 95, 95, "Szabad" },
                    { 96, 96, "Szabad" },
                    { 97, 97, "Szabad" },
                    { 98, 98, "Szabad" },
                    { 99, 99, "Szabad" },
                    { 100, 100, "Szabad" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
