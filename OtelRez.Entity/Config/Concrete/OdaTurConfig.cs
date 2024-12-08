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
        }
    }
}
