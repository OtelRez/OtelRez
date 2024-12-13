using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtelRez.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DogumTarihi = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.Id);
                });

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
                name: "Personeller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IzinHakki = table.Column<int>(type: "int", nullable: false, defaultValue: 30),
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

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Id",
                table: "Kullanicilar",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Mail",
                table: "Kullanicilar",
                column: "Mail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_Tel",
                table: "Kullanicilar",
                column: "Tel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Odalar_Id",
                table: "Odalar",
                column: "Id");

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
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OdaTurleri_TurAdi",
                table: "OdaTurleri",
                column: "TurAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonelGiris_Id",
                table: "PersonelGiris",
                column: "Id");

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
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_PersonelMeslekId",
                table: "Personeller",
                column: "PersonelMeslekId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMeslekler_Id",
                table: "PersonelMeslekler",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelMeslekler_Meslek",
                table: "PersonelMeslekler",
                column: "Meslek",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_Id",
                table: "Rezervasyonlar",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_KullaniciId",
                table: "Rezervasyonlar",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervasyonlar_OdaId",
                table: "Rezervasyonlar",
                column: "OdaId",
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
                name: "OdaTurleri");
        }
    }
}
