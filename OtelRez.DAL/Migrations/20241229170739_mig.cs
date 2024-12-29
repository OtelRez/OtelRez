using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtelRez.DAL.Migrations
{
    /// <inheritdoc />
    public partial class mig : Migration
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

            migrationBuilder.CreateTable(
                name: "Hizmetler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hizmetler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Iletisim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tel = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iletisim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimeGec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Konu = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Mesaj = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimeGec", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuKategoriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuKategoriler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OdaTurleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TurDetay = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Kapasite = table.Column<short>(type: "smallint", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balkon = table.Column<bool>(type: "bit", nullable: false),
                    WiFi = table.Column<bool>(type: "bit", nullable: false),
                    Jakuzi = table.Column<bool>(type: "bit", nullable: false),
                    OdaServisi = table.Column<bool>(type: "bit", nullable: false),
                    Minibar = table.Column<bool>(type: "bit", nullable: false)
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
                    Meslek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
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
                name: "Menuler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UrunAciklama = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    MenuKategoriId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menuler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menuler_MenuKategoriler_MenuKategoriId",
                        column: x => x.MenuKategoriId,
                        principalTable: "MenuKategoriler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Odalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdaNumarasi = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    OdaTurId = table.Column<int>(type: "int", nullable: false)
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
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
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
                    PersonelMeslekId = table.Column<int>(type: "int", nullable: false),
                    Maas = table.Column<int>(type: "int", nullable: false)
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
                    Giris = table.Column<DateOnly>(type: "date", nullable: false),
                    Cikis = table.Column<DateOnly>(type: "date", nullable: false),
                    CreateTime = table.Column<DateOnly>(type: "date", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    OdaId = table.Column<int>(type: "int", nullable: false),
                    ToplamTutar = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Hizmetler",
                columns: new[] { "Id", "Description", "PhotoPath", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "asjhvhdsvhfsvdhsbh", "/OtelTemp/assets/img/dining/dining-img.jpg", "Akşam yemeği ve kahvaltı", "Restoranımız" },
                    { 2, "asjhvhdsvhfsvdhsbh", "/OtelTemp/assets/img/dining/dining-img2.jpg", "Büyük yüzme havuzu", "Havuzumuz" }
                });

            migrationBuilder.InsertData(
                table: "Iletisim",
                columns: new[] { "Id", "Adres", "Mail", "Tel" },
                values: new object[] { 1, "İstanbul,Beşiktaş", "istkafullkata@gmail.com", "0212 568 93 96" });

            migrationBuilder.InsertData(
                table: "MenuKategoriler",
                columns: new[] { "Id", "KategoriAdi" },
                values: new object[,]
                {
                    { 1, "Kahvaltı" },
                    { 2, "Atıştırmalık" },
                    { 3, "Ana Yemek" },
                    { 4, "Tatlı" },
                    { 5, "İçecek" }
                });

            migrationBuilder.InsertData(
                table: "OdaTurleri",
                columns: new[] { "Id", "Balkon", "Fiyat", "Jakuzi", "Kapasite", "Minibar", "OdaServisi", "PhotoPath", "TurAdi", "TurDetay", "WiFi" },
                values: new object[,]
                {
                    { 1, false, 1500, false, (short)1, false, true, "/OtelTemp/assets/img/rooms/room1.jpg", "Suit Room", "Tek yataklı oda", true },
                    { 2, false, 1600, false, (short)2, false, true, "/OtelTemp/assets/img/rooms/room2.jpg", "Twin Room", "İki yataklı oda", true },
                    { 3, true, 1700, false, (short)2, false, true, "/OtelTemp/assets/img/rooms/room3.jpg", "Double Room", "İki kişilik tek yatak", true },
                    { 4, true, 1800, false, (short)3, true, true, "/OtelTemp/assets/img/rooms/room4.jpg", "Triple Room", "Üç tek kişilik yatak", true },
                    { 5, true, 1750, false, (short)3, true, true, "/OtelTemp/assets/img/rooms/room5.jpg", "Family Room", "1 double yatak 1 tek kişilik yatak", true },
                    { 6, true, 3000, true, (short)2, true, true, "/OtelTemp/assets/img/rooms/room6.jpg", "King Room", "Double yatak", true }
                });

            migrationBuilder.InsertData(
                table: "PersonelMeslekler",
                columns: new[] { "Id", "Meslek" },
                values: new object[,]
                {
                    { 1, "Yönetici" },
                    { 2, "Resepsiyonist" },
                    { 3, "Aşçı" }
                });

            migrationBuilder.InsertData(
                table: "Roller",
                columns: new[] { "Id", "RoleAdi" },
                values: new object[,]
                {
                    { 1, "Yönetici" },
                    { 2, "Resepsiyonist" },
                    { 3, "Kullanıcı" }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "Id", "Adi", "DogumTarihi", "Mail", "RoleId", "Sifre", "Soyadi", "Tel" },
                values: new object[,]
                {
                    { 1, "Emre", new DateOnly(1998, 9, 9), "emre@gmail.com", 3, "qweasd", "Andaç", "05456853541" },
                    { 2, "Betül Rana", new DateOnly(1998, 9, 9), "betul@gmail.com", 3, "qweasd", "Özer", "05648623598" }
                });

            migrationBuilder.InsertData(
                table: "Menuler",
                columns: new[] { "Id", "Fiyat", "MenuKategoriId", "UrunAciklama", "UrunAdi" },
                values: new object[,]
                {
                    { 1, 250, 1, "Peynir çeşitleri, domates, salatalık, mevsim yeşilliği, zeytin çeşitleri, yumurta, reçel, bal, tereyeğ ve çay ile servis edilir", "Kahvaltı Tabağı" },
                    { 2, 80, 1, "Çırpılmış yumurta, domates ve mevsim yeşilliği", "Sade Omlet" },
                    { 3, 100, 1, "Peynirli çırpılmış yumurta, domates ve mevsim yeşilliği", "Peynirli Omlet" },
                    { 4, 150, 1, "Sade, sucuklu, kaşarlı seçenekleri", "Menemen" },
                    { 5, 120, 1, "Kaşar, peynir, karışık seçenekleri", "Tost" },
                    { 6, 140, 1, "Kaşar, peynir, kıyma, patates seçenekleri", "Gözleme" },
                    { 7, 140, 1, "Kaşar, peynir, kıyma, patates seçenekleri", "Börek" },
                    { 8, 110, 2, "Günün çorbası", "Çorba" },
                    { 9, 200, 2, "Patates kızartması, sosis, sigara böreği, soğan halkası", "Kızarmış Lezzet Sepeti" },
                    { 10, 80, 2, "Patates kızartması", "Parmak Patates" },
                    { 11, 90, 2, "Tahinli yoğurt ve mevsim yeşilliği ile servis edilir", "Falafel" },
                    { 12, 300, 3, "Pilav / makarna ve salata ile servis edilir", "Izgara Tavuk" },
                    { 13, 350, 3, "Pilav / makarna ve salata ile servis edilir", "Izgara Köfte" },
                    { 14, 300, 3, "Mantar, kapya biber ile pişirilmiş tavu bonfile, makarna ve patates ile servis edilir", "Soya Soslu Tavuk" },
                    { 15, 200, 3, "Acılı arrabbiata sosu, zeytin dilimleri, sarımsak, pesto sos ve parmesan", "Penne Arrabbiata" },
                    { 16, 250, 3, "Tavuk, mantar, sarımsak, pesto sos, parmesan ve krema", "Fettuccine Alfredo" },
                    { 17, 300, 3, "Mozzarella, domates sos, sucuk, sosis, salam, mantar, yeşil biber, mısır, domates, siyah zeytin, yeşil zeytin", "Karışık Pizza" },
                    { 18, 250, 3, "Mozzarella, domates sos", "Margarita Pizza" },
                    { 19, 285, 3, "Mozzarella, domates sos, salam, mantar, yeşil biber, domates, soğan", "Akdeniz Pizza" },
                    { 20, 200, 4, "Brownie küpleri, taze çilek, özel krema", "Everest" },
                    { 21, 250, 4, "Dondurma ile servis edilir", "Brownie" },
                    { 22, 250, 4, "Çilekli, çikolatalatı, lotuslu seçenekleri", "Pasta" },
                    { 23, 280, 4, "3 dilim olarak servis edilir", "Baklava" },
                    { 24, 255, 4, "Dondurma ile servis edilir", "Künefe" },
                    { 25, 20, 5, null, "Su" },
                    { 26, 25, 5, null, "Çay" },
                    { 27, 55, 5, null, "Türk Kahvesi" },
                    { 28, 170, 5, null, "Caffe Latte" },
                    { 29, 170, 5, null, "Cappuccino" },
                    { 30, 150, 5, null, "Filtre Kahve" },
                    { 31, 140, 5, null, "Ice Americano" },
                    { 32, 155, 5, null, "Ice Latte" },
                    { 33, 135, 5, null, "Limonata" },
                    { 34, 150, 5, null, "Portakal Suyu" },
                    { 35, 40, 5, null, "Maden Suyu" }
                });

            migrationBuilder.InsertData(
                table: "Odalar",
                columns: new[] { "Id", "OdaNumarasi", "OdaTurId" },
                values: new object[,]
                {
                    { 1, "101", 1 },
                    { 2, "102", 1 },
                    { 3, "103", 4 },
                    { 4, "104", 4 },
                    { 5, "105", 4 },
                    { 6, "201", 2 },
                    { 7, "202", 2 },
                    { 8, "203", 3 },
                    { 9, "204", 3 },
                    { 10, "205", 3 },
                    { 11, "301", 1 },
                    { 12, "302", 2 },
                    { 13, "303", 3 },
                    { 14, "304", 5 },
                    { 15, "305", 5 },
                    { 16, "401", 6 },
                    { 17, "405", 6 }
                });

            migrationBuilder.InsertData(
                table: "Personeller",
                columns: new[] { "Id", "Adi", "IzinHakki", "Maas", "PersonelMeslekId", "RoleId", "Soyadi" },
                values: new object[,]
                {
                    { 1, "Ahmet", 30, 50000, 1, 1, "Ak" },
                    { 2, "Büşra", 20, 28000, 2, 2, "Aksoy" },
                    { 3, "Betüş", 20, 35000, 3, null, "Yılmaz" }
                });

            migrationBuilder.InsertData(
                table: "PersonelGiris",
                columns: new[] { "Id", "Mail", "PersonelId", "Sifre" },
                values: new object[,]
                {
                    { 1, "ahmet@gmail.com", 1, "qweasd" },
                    { 2, "busr.ar@gmail.com", 2, "qweasd" }
                });

            migrationBuilder.InsertData(
                table: "Rezervasyonlar",
                columns: new[] { "Id", "Cikis", "CreateTime", "Giris", "KullaniciId", "OdaId", "ToplamTutar" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 12, 22), new DateOnly(2024, 12, 29), new DateOnly(2024, 12, 18), 1, 12, 4000 },
                    { 2, new DateOnly(2024, 12, 22), new DateOnly(2024, 12, 29), new DateOnly(2024, 12, 20), 1, 4, 2000 },
                    { 3, new DateOnly(2024, 12, 5), new DateOnly(2024, 12, 29), new DateOnly(2024, 11, 18), 2, 10, 20000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Galeriler_Id",
                table: "Galeriler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_Id",
                table: "Hizmetler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_SubTitle",
                table: "Hizmetler",
                column: "SubTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hizmetler_Title",
                table: "Hizmetler",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Iletisim_Id",
                table: "Iletisim",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IletisimeGec_Id",
                table: "IletisimeGec",
                column: "Id",
                unique: true);

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
                name: "IX_MenuKategoriler_Id",
                table: "MenuKategoriler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuKategoriler_KategoriAdi",
                table: "MenuKategoriler",
                column: "KategoriAdi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_Id",
                table: "Menuler",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_MenuKategoriId",
                table: "Menuler",
                column: "MenuKategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Menuler_UrunAdi",
                table: "Menuler",
                column: "UrunAdi",
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
                name: "Galeriler");

            migrationBuilder.DropTable(
                name: "Hizmetler");

            migrationBuilder.DropTable(
                name: "Iletisim");

            migrationBuilder.DropTable(
                name: "IletisimeGec");

            migrationBuilder.DropTable(
                name: "Menuler");

            migrationBuilder.DropTable(
                name: "PersonelGiris");

            migrationBuilder.DropTable(
                name: "Rezervasyonlar");

            migrationBuilder.DropTable(
                name: "MenuKategoriler");

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
