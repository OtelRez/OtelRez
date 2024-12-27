using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtelRez.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Galeriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOda = table.Column<bool>(type: "bit", nullable: false),
                    IsRestorant = table.Column<bool>(type: "bit", nullable: false),
                    IsPool = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galeriler", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Galeriler",
                columns: new[] { "Id", "IsOda", "IsPool", "IsRestorant", "PhotoPath" },
                values: new object[,]
                {
                    { 1, true, false, false, "/OtelTemp/assets/img/rooms/room1.jpg" },
                    { 2, true, false, false, "/OtelTemp/assets/img/rooms/room2.jpg" },
                    { 3, true, false, false, "/OtelTemp/assets/img/rooms/room3.jpg" },
                    { 4, true, false, false, "/OtelTemp/assets/img/rooms/room4.jpg" },
                    { 5, true, false, false, "/OtelTemp/assets/img/rooms/room5.jpg" },
                    { 6, true, false, false, "/OtelTemp/assets/img/gallery/gallery1.jpg" },
                    { 7, true, false, false, "/OtelTemp/assets/img/gallery/gallery2.jpg" },
                    { 8, true, false, false, "/OtelTemp/assets/img/gallery/gallery3.jpg" },
                    { 9, false, false, true, "/OtelTemp/assets/img/dining/dining-img.jpg" },
                    { 10, false, true, false, "/OtelTemp/assets/img/dining/dining-img2.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Hizmetler",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: "/OtelTemp/assets/img/dining/dining-img.jpg");

            migrationBuilder.UpdateData(
                table: "Hizmetler",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: "/OtelTemp/assets/img/dining/dining-img2.jpg");

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 27));

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 27));

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 27));

            migrationBuilder.CreateIndex(
                name: "IX_Galeriler_Id",
                table: "Galeriler",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Galeriler");

            migrationBuilder.UpdateData(
                table: "Hizmetler",
                keyColumn: "Id",
                keyValue: 1,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Hizmetler",
                keyColumn: "Id",
                keyValue: 2,
                column: "PhotoPath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 26));

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 26));

            migrationBuilder.UpdateData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateTime",
                value: new DateOnly(2024, 12, 26));
        }
    }
}
