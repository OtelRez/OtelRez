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
    public class PersonelGirisConfig : BaseConfig<PersonelGiris>
    {
        public override void Configure(EntityTypeBuilder<PersonelGiris> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.HasIndex(p => p.Mail).IsUnique();
            builder.Property(p => p.Mail).IsRequired();
            builder.Property(p=>p.Sifre).HasMaxLength(16);
            builder.Property(p => p.Sifre).IsRequired();

        }
    }
}
