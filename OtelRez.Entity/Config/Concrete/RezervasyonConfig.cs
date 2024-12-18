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

            builder.HasData(new Rezervasyon() { Id = 1, Giris = DateOnly.Parse("2024-12-18"), Cikis = DateOnly.Parse("2024-12-22"), KullaniciId = 1, OdaId = 12 , ToplamTutar = 4000 });
            builder.HasData(new Rezervasyon() { Id = 2, Giris = DateOnly.Parse("2024-12-20"), Cikis = DateOnly.Parse("2024-12-22"), KullaniciId = 1, OdaId = 4 , ToplamTutar = 2000});
            builder.HasData(new Rezervasyon() { Id = 3, Giris = DateOnly.Parse("2024-11-18"), Cikis = DateOnly.Parse("2024-12-05"), KullaniciId = 2, OdaId = 10, ToplamTutar = 20000 });


        }
    }
}
