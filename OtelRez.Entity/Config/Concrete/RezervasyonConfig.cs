using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelRez.Entity.Config.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class RezervasyonConfig : BaseConfig<Rezervasyon>
    {
        public override void Configure(EntityTypeBuilder<Rezervasyon> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Giris).IsRequired();
            builder.Property(p => p.Cikis).IsRequired();

            builder.Property(p => p.KullaniciId).IsRequired();

            builder.HasOne(p => p.Kullanici)
                .WithMany(p => p.Rezervasyonlar)
                .HasForeignKey(p => p.KullaniciId);


            builder.HasOne(p => p.Oda)
               .WithMany(p => p.Rezervasyon)
               .HasForeignKey(p => p.OdaId);

            builder.HasData(new Rezervasyon() { Id = 1, Giris = DateTime.Parse("2024-12-18"), Cikis = DateTime.Parse("2024-12-22"), KullaniciId = 1, OdaId = 12 , ToplamTutar = 6400 });
            builder.HasData(new Rezervasyon() { Id = 2, Giris = DateTime.Parse("2024-12-20"), Cikis = DateTime.Parse("2024-12-22"), KullaniciId = 1, OdaId = 4 , ToplamTutar = 3600});
            builder.HasData(new Rezervasyon() { Id = 3, Giris = DateTime.Parse("2024-11-18"), Cikis = DateTime.Parse("2024-12-22"), KullaniciId = 2, OdaId = 10, ToplamTutar = 6800 });
            builder.HasData(new Rezervasyon() { Id = 4, Giris = DateTime.Parse("2025-02-25"), Cikis = DateTime.Parse("2025-02-27"), KullaniciId = 2, OdaId = 7, ToplamTutar = 3200 });
            builder.HasData(new Rezervasyon() { Id = 5, Giris = DateTime.Parse("2025-03-12"), Cikis = DateTime.Parse("2025-03-15"), KullaniciId = 1, OdaId = 16, ToplamTutar = 9000 });
        }
    }
}
