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
    public class OdaConfig : BaseConfig<Oda>
    {
        public override void Configure(EntityTypeBuilder<Oda> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.OdaNumarasi).HasMaxLength(3);
            builder.HasIndex(p => p.OdaNumarasi).IsUnique();
            builder.Property(p => p.OdaNumarasi).IsRequired();
            builder.Property(p => p.Fiyat).IsRequired();
            builder.Property(p => p.Musait).IsRequired();
            builder.Property(p => p.Musait).HasDefaultValue(true);
        }
    }
}
