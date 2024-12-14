using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtelRez.DAL.Migrations
{
    /// <inheritdoc />
    public partial class fer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "Odalar");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Giris",
                table: "Rezervasyonlar",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CreateTime",
                table: "Rezervasyonlar",
                type: "date",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Cikis",
                table: "Rezervasyonlar",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Fiyat",
                table: "OdaTurleri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "Adi", "DogumTarihi", "Mail", "RoleId", "Sifre", "Soyadi", "Tel" },
                values: new object[] { 1, "Emre", new DateOnly(1998, 9, 9), "emre@gmail.com", 3, "qweasd", "Andaç", "05456853541" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Fiyat", "TurAdi" },
                values: new object[] { 1500, "Tek Kişilik" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Fiyat", "TurAdi" },
                values: new object[] { 1600, "İki Kişilik" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Fiyat", "TurAdi" },
                values: new object[] { 1700, "İki Kişilik Double" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Fiyat", "TurAdi", "TurDetay" },
                values: new object[] { 1800, "Üç Kişilik", "Üç tek kişilik yatak" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Fiyat", "TurAdi" },
                values: new object[] { 1750, "Üç Kişilik Double" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 6,
                column: "Fiyat",
                value: 3000);

            migrationBuilder.InsertData(
                table: "Odalar",
                columns: new[] { "Id", "Musait", "OdaNumarasi", "OdaTurId" },
                values: new object[,]
                {
                    { 1, true, "101", 1 },
                    { 2, true, "102", 1 },
                    { 3, true, "103", 4 },
                    { 4, true, "104", 4 },
                    { 5, true, "105", 4 },
                    { 6, true, "201", 2 },
                    { 7, true, "202", 2 },
                    { 8, true, "203", 3 },
                    { 9, true, "204", 3 },
                    { 10, true, "205", 3 },
                    { 11, true, "301", 1 },
                    { 12, true, "302", 2 },
                    { 13, true, "303", 3 },
                    { 14, true, "304", 5 },
                    { 15, true, "305", 5 },
                    { 16, true, "401", 6 },
                    { 17, true, "405", 6 }
                });

            migrationBuilder.InsertData(
                table: "PersonelMeslekler",
                columns: new[] { "Id", "Maas", "Meslek" },
                values: new object[,]
                {
                    { 1, 50000, "Yönetici" },
                    { 2, 18002, "Resepsiyonist" },
                    { 3, 25000, "Aşçı" }
                });

            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "Adi", "IzinHakki", "PersonelMeslekId", "RoleId", "Soyadi" },
                values: new object[,]
                {
                    { 1, "Ahmet", 30, 1, 1, "Ak" },
                    { 2, "Büşra", 20, 2, 2, "Aksoy" },
                    { 3, "Betüş", 14, 3, null, "Lol" }
                });

            migrationBuilder.InsertData(
                table: "Rezervasyonlar",
                columns: new[] { "Id", "Cikis", "CreateTime", "Giris", "KullaniciId", "OdaId" },
                values: new object[] { 1, new DateOnly(2024, 12, 22), new DateOnly(2024, 12, 14), new DateOnly(2024, 12, 18), 1, 12 });

            migrationBuilder.InsertData(
                table: "PersonelGiris",
                columns: new[] { "Id", "Mail", "PersonelId", "Sifre" },
                values: new object[,]
                {
                    { 1, "ahmet@gmail.com", 1, "qweasd" },
                    { 2, "busr.ar@gmail.com", 2, "qweasd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "PersonelGiris",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonelGiris",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rezervasyonlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Odalar",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PersonelMeslekler",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personeller",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonelMeslekler",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonelMeslekler",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Fiyat",
                table: "OdaTurleri");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Giris",
                table: "Rezervasyonlar",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateTime",
                table: "Rezervasyonlar",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Cikis",
                table: "Rezervasyonlar",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<int>(
                name: "Fiyat",
                table: "Odalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 1,
                column: "TurAdi",
                value: "Tek Kisilik");

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 2,
                column: "TurAdi",
                value: "İki Kisilik");

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 3,
                column: "TurAdi",
                value: "İki Kisilik Double");

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "TurAdi", "TurDetay" },
                values: new object[] { "Uc Kisilik", "Üç tek kişilik" });

            migrationBuilder.UpdateData(
                table: "OdaTurleri",
                keyColumn: "Id",
                keyValue: 5,
                column: "TurAdi",
                value: "Uc Kisilik Double");
        }
    }
}
