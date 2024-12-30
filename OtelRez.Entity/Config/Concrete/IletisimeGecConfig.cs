using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelRez.Entity.Config.Abstract;
using OtelRez.Entity.Entities.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class IletisimeGecConfig : BaseConfig<IletisimeGec>
    {
        public override void Configure(EntityTypeBuilder<IletisimeGec> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Adi).HasMaxLength(50);
            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.Property(p => p.Konu).HasMaxLength(100);
            builder.Property(p => p.Mesaj).HasMaxLength(500);

            builder.HasData(new IletisimeGec() { Id = 1, Adi = "Ayşe Can", Mail = "ayse@gmail.com", Konu = "İndirim", Mesaj = "Rezervasyonu erken tarihte oluşturunca uyguladığınız bir indirim var mı?" });
            builder.HasData(new IletisimeGec() { Id = 2, Adi = "Mehmet Yılmaz", Mail = "mehmet@gmail.com", Konu = "Otelde davet düzenleme", Mesaj = "Otelinizde davet vermek istediğimiz durumda bize sunabileceğiniz imkanlar neler ve bu konu hakkında kiminle iletişime geçmemiz gerekir?" });
            builder.HasData(new IletisimeGec() { Id = 3, Adi = "Sude Kaya", Mail = "sude@gmail.com", Konu = "Hizmetleriniz", Mesaj = "Otelinizde çocuklar için sağladığınız imkanlar neler? Yaz aylarında düzenlediğiniz etkinlikler var mı?" });
        }
    }
}
