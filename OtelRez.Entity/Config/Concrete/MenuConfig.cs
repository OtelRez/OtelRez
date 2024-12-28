using OtelRez.Entity.Config.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class MenuConfig : BaseConfig<Menu>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Menu> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.UrunAdi).HasMaxLength(50);
            builder.Property(p => p.UrunAdi).IsRequired();
            builder.HasIndex(p => p.UrunAdi).IsUnique();

            builder.Property(p => p.UrunAciklama).HasMaxLength(500);

            builder.Property(p => p.Fiyat).IsRequired();

            builder.HasOne(p => p.MenuKategori)
                .WithMany(p => p.Menu)
                .HasForeignKey(p => p.MenuKategoriId);

            builder.HasData(new Menu() { Id = 1, UrunAdi = "Kahvaltı Tabağı", UrunAciklama = "Peynir çeşitleri, domates, salatalık, mevsim yeşilliği, zeytin çeşitleri, yumurta, reçel, bal, tereyeğ ve çay ile servis edilir", Fiyat = 250, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 2, UrunAdi = "Sade Omlet", UrunAciklama = "Çırpılmış yumurta, domates ve mevsim yeşilliği", Fiyat = 80, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 3, UrunAdi = "Peynirli Omlet", UrunAciklama = "Peynirli çırpılmış yumurta, domates ve mevsim yeşilliği", Fiyat = 100, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 4, UrunAdi = "Menemen", UrunAciklama = "Sade, sucuklu, kaşarlı seçenekleri", Fiyat = 150, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 5, UrunAdi = "Tost", UrunAciklama = "Kaşar, peynir, karışık seçenekleri", Fiyat = 120, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 6, UrunAdi = "Gözleme", UrunAciklama = "Kaşar, peynir, kıyma, patates seçenekleri", Fiyat = 140, MenuKategoriId = 1 });
            builder.HasData(new Menu() { Id = 7, UrunAdi = "Börek", UrunAciklama = "Kaşar, peynir, kıyma, patates seçenekleri", Fiyat = 140, MenuKategoriId = 1 });

            builder.HasData(new Menu() { Id = 8, UrunAdi = "Çorba", UrunAciklama = "Günün çorbası", Fiyat = 110, MenuKategoriId = 2 });
            builder.HasData(new Menu() { Id = 9, UrunAdi = "Kızarmış Lezzet Sepeti", UrunAciklama = "Patates kızartması, sosis, sigara böreği, soğan halkası", Fiyat = 200, MenuKategoriId = 2 });
            builder.HasData(new Menu() { Id = 10, UrunAdi = "Parmak Patates", UrunAciklama = "Patates kızartması", Fiyat = 80, MenuKategoriId = 2 });
            builder.HasData(new Menu() { Id = 11, UrunAdi = "Falafel", UrunAciklama = "Tahinli yoğurt ve mevsim yeşilliği ile servis edilir", Fiyat = 90, MenuKategoriId = 2 });

            builder.HasData(new Menu() { Id = 12, UrunAdi = "Izgara Tavuk", UrunAciklama = "Pilav / makarna ve salata ile servis edilir", Fiyat = 300, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 13, UrunAdi = "Izgara Köfte", UrunAciklama = "Pilav / makarna ve salata ile servis edilir", Fiyat = 350, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 14, UrunAdi = "Soya Soslu Tavuk", UrunAciklama = "Mantar, kapya biber ile pişirilmiş tavu bonfile, makarna ve patates ile servis edilir", Fiyat = 300, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 15, UrunAdi = "Penne Arrabbiata", UrunAciklama = "Acılı arrabbiata sosu, zeytin dilimleri, sarımsak, pesto sos ve parmesan", Fiyat = 200, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 16, UrunAdi = "Fettuccine Alfredo", UrunAciklama = "Tavuk, mantar, sarımsak, pesto sos, parmesan ve krema", Fiyat = 250, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 17, UrunAdi = "Karışık Pizza", UrunAciklama = "Mozzarella, domates sos, sucuk, sosis, salam, mantar, yeşil biber, mısır, domates, siyah zeytin, yeşil zeytin", Fiyat = 300, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 18, UrunAdi = "Margarita Pizza", UrunAciklama = "Mozzarella, domates sos", Fiyat = 250, MenuKategoriId = 3 });
            builder.HasData(new Menu() { Id = 19, UrunAdi = "Akdeniz Pizza", UrunAciklama = "Mozzarella, domates sos, salam, mantar, yeşil biber, domates, soğan", Fiyat = 285, MenuKategoriId = 3 });

            builder.HasData(new Menu() { Id = 20, UrunAdi = "Everest", UrunAciklama = "Brownie küpleri, taze çilek, özel krema", Fiyat = 200, MenuKategoriId = 4 });
            builder.HasData(new Menu() { Id = 21, UrunAdi = "Brownie", UrunAciklama = "Dondurma ile servis edilir", Fiyat = 250, MenuKategoriId = 4 });
            builder.HasData(new Menu() { Id = 22, UrunAdi = "Pasta", UrunAciklama = "Çilekli, çikolatalatı, lotuslu seçenekleri", Fiyat = 250, MenuKategoriId = 4 });
            builder.HasData(new Menu() { Id = 23, UrunAdi = "Baklava", UrunAciklama = "3 dilim olarak servis edilir", Fiyat = 280, MenuKategoriId = 4 });
            builder.HasData(new Menu() { Id = 24, UrunAdi = "Künefe", UrunAciklama = "Dondurma ile servis edilir", Fiyat = 255, MenuKategoriId = 4 });

            builder.HasData(new Menu() { Id = 25, UrunAdi = "Su", Fiyat = 20, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 26, UrunAdi = "Çay", Fiyat = 25, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 27, UrunAdi = "Türk Kahvesi", Fiyat = 55, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 28, UrunAdi = "Caffe Latte", Fiyat = 170, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 29, UrunAdi = "Cappuccino", Fiyat = 170, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 30, UrunAdi = "Filtre Kahve", Fiyat = 150, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 31, UrunAdi = "Ice Americano", Fiyat = 140, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 32, UrunAdi = "Ice Latte", Fiyat = 155, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 33, UrunAdi = "Limonata", Fiyat = 135, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 34, UrunAdi = "Portakal Suyu", Fiyat = 150, MenuKategoriId = 5 });
            builder.HasData(new Menu() { Id = 35, UrunAdi = "Maden Suyu", Fiyat = 40, MenuKategoriId = 5 });
        }
    }
}
