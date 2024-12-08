using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelRez.Entity.Config.Abstract;
using OtinternalEntity.Entitieste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class PersonelConfig : BaseConfig<Personel>
    {
        public override void Configure(EntityTypeBuilder<Personel> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Adi).HasMaxLength(15);
            builder.Property(p => p.Adi).IsRequired();

            builder.Property(p => p.Soyadi).HasMaxLength(15);
            builder.Property(p => p.Soyadi).IsRequired();

            builder.Property(p => p.IzinHakki).IsRequired();
            builder.Property(p=>p.IzinHakki).HasDefaultValue(30);
        }
    }
}
