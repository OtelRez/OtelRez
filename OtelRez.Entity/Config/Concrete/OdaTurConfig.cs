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
    public class OdaTurConfig :BaseConfig<OdaTur>
    {
        public override void Configure(EntityTypeBuilder<OdaTur> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.TurAdi).HasMaxLength(50);
            builder.HasIndex(p => p.TurAdi).IsUnique();
            builder.Property(p => p.TurDetay).HasMaxLength(500);
            builder.Property(p => p.TurAdi).IsRequired();
            builder.Property(p => p.TurDetay).IsRequired();
            builder.Property(p => p.Kapasite).IsRequired();
            builder.Property(p => p.Fiyat).IsRequired();

            builder.HasData(new OdaTur() { Id=1,TurAdi = "Tek Kişilik", TurDetay = "Tek yataklı oda", Kapasite = 1, Fiyat = 1500, PhotoPath= "/OtelTemp/assets/img/rooms/room1.jpg" });
            builder.HasData(new OdaTur() { Id=2,TurAdi = "İki Kişilik", TurDetay = "İki yataklı oda", Kapasite = 2, Fiyat = 1600, PhotoPath = "/OtelTemp/assets/img/rooms/room2.jpg" });
            builder.HasData(new OdaTur() { Id=3,TurAdi = "İki Kişilik Double", TurDetay = "İki kişilik tek yatak", Kapasite = 2, Fiyat = 1700, PhotoPath = "/OtelTemp/assets/img/rooms/room3.jpg" });
            builder.HasData(new OdaTur() { Id=4,TurAdi = "Üç Kişilik", TurDetay = "Üç tek kişilik yatak", Kapasite = 3 , Fiyat = 1800, PhotoPath = "/OtelTemp/assets/img/rooms/room4.jpg" });
            builder.HasData(new OdaTur() { Id=5,TurAdi = "Üç Kişilik Double", TurDetay = "1 double yatak 1 tek kişilik yatak", Kapasite = 3, Fiyat = 1750, PhotoPath = "/OtelTemp/assets/img/rooms/room5.jpg" });
            builder.HasData(new OdaTur() { Id=6,TurAdi = "King", TurDetay = "Double yatak", Kapasite = 2, Fiyat = 3000, PhotoPath = "/OtelTemp/assets/img/rooms/room6.jpg" });

        }
    }
}
