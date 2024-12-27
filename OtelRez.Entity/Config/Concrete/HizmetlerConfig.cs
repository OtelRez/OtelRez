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

            builder.HasData(new Hizmetler() { Id = 1, Title = "Restoranımız", SubTitle = "Akşam yemeği ve kahvaltı", Description = "asjhvhdsvhfsvdhsbh", PhotoPath= "/OtelTemp/assets/img/dining/dining-img.jpg" });
            builder.HasData(new Hizmetler() { Id = 2, Title = "Havuzumuz", SubTitle = "Büyük yüzme havuzu", Description = "asjhvhdsvhfsvdhsbh", PhotoPath= "/OtelTemp/assets/img/dining/dining-img2.jpg" });
        }
    }
}
