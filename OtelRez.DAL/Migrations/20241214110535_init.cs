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
                name: "OdaTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TurDetay = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Kapasite = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OdaTurleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonelMeslekler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Meslek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Maas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelMeslekler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaNumarasi = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    OdaTurId = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    Musait = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odalar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odalar_OdaTurleri_OdaTurId",
                        column: x => x.OdaTurId,
                        principalTable: "OdaTurleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Tel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DogumTarihi = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_Roller_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IzinHakki = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    PersonelMeslekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Personeller_PersonelMeslekler_PersonelMeslekId",
                        column: x => x.PersonelMeslekId,
                        principalTable: "PersonelMeslekler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personeller_Roller_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rezervasyonlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Giris = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cikis = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervasyonlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Kullanicilar_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "Kullanicilar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rezervasyonlar_Odalar_OdaId",
                        column: x => x.OdaId,
                        principalTable: "Odalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonelGiris",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelGiris", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonelGiris_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OdaTurleri",
                columns: new[] { "Id", "Kapasite", "TurAdi", "TurDetay" },
                values: new object[,]
                {
                    { 1, (short)1, "Tek Kisilik", "Tek yataklı oda" },
                    { 2, (short)2, "İki Kisilik", "İki yataklı oda" },
                    { 3, (short)2, "İki Kisilik Double", "İki kişilik tek yatak" },
                    { 4, (short)3, "Uc Kisilik", "Üç tek kişilik" },
                    { 5, (short)3, "Uc Kisilik Double", "1 double yatak 1 tek kişilik yatak" },
                    { 6, (short)2, "King", "Double yatak" }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "RoleAdi" },
                values: new object[,]
                {
                    { 1, "Yonetici" },
                    { 2, "Resepsiyonist" },
                    { 3, "Kullanici" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Id",
                table: "Kullanicilar",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Mail",
                table: "Kullanicilar",
                column: "Mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_RoleId",
                table: "Kullanicilar",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Tel",
                table: "Kullanicilar",
                column: "Tel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_Id",
                table: "Odalar",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_OdaNumarasi",
                table: "Odalar",
                column: "OdaNumarasi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_OdaTurId",
                table: "Odalar",
                column: "OdaTurId");

            migrationBuilder.CreateIndex(
                name: "IX_OdaTurleri_Id",
                table: "OdaTurleri",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OdaTurleri_TurAdi",
                table: "OdaTurleri",
                column: "TurAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGiris_Id",
                table: "PersonelGiris",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGiris_Mail",
                table: "PersonelGiris",
                column: "Mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGiris_PersonelId",
                table: "PersonelGiris",
                column: "PersonelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_Id",
                table: "Personeller",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_PersonelMeslekId",
                table: "Personeller",
                column: "PersonelMeslekId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_RoleId",
                table: "Personeller",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMeslekler_Id",
                table: "PersonelMeslekler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMeslekler_Meslek",
                table: "PersonelMeslekler",
                column: "Meslek",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_Id",
                table: "Rezervasyonlar",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullaniciId",
                table: "Rezervasyonlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaId",
                table: "Rezervasyonlar",
                column: "OdaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roller_Id",
                table: "Roller",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roller_RoleAdi",
                table: "Roller",
                column: "RoleAdi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonelGiris");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Odalar");

            migrationBuilder.DropTable(
                name: "PersonelMeslekler");

            migrationBuilder.DropTable(
                name: "Roller");

            migrationBuilder.DropTable(
                name: "OdaTurleri");
        }
    }
}
