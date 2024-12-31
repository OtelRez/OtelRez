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
    public class HizmetlerConfig : BaseConfig<Hizmetler>
    {
        public override void Configure(EntityTypeBuilder<Hizmetler> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Title).IsRequired();
            builder.HasIndex(p => p.Title).IsUnique();
            builder.Property(p => p.Title).HasMaxLength(50);

            builder.Property(p => p.SubTitle).IsRequired();
            builder.HasIndex(p => p.SubTitle).IsUnique();
            builder.Property(p => p.SubTitle).HasMaxLength(50);

            builder.Property(p => p.Description).IsRequired();

            builder.HasData(new Hizmetler() { Id = 1, Title = "Restoranımız", SubTitle = "Kahvaltı ve Akşam Yemeği", 
                Description = "Başarılı şeflerimiz sizi gastronomik bir yolculuğa çıkaran eşsiz lezzetleriyle büyülemeye hazır! Her yemek, bir sanat eseri gibi hazırlanır ve eşsiz bir sunumla servis edilir.", 
                PhotoPath= "/OtelTemp/assets/img/dining/dining-img.jpg" 
            });

            builder.HasData(new Hizmetler() { Id = 2, Title = "Havuzlarımız", SubTitle = "Yüzme Havuzları ve Su Parkı", 
                Description = "Otelimizin yüzme havuzları ve su parkı, tatilinize serinlik ve huzur katmak için tasarlandı! Açık havuzumuz göz alıcı manzarasıyla sizi büyülerken ısıtmalı kapalı havuzumuz her mevsim keyifle yüzme imkanı sunar. Çocuklar için özel güvenli yüzme alanlarımız ise ailelere unutulmaz anılar yaşatır. Kusursuz bir havuz deneyimi yaşamak için sizi otelimizin havuzlarına davet ediyoruz!", 
                PhotoPath= "/OtelTemp/assets/img/dining/dining-img2.jpg" 
            });
        }
    }
}
