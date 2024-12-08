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
    public class KullaniciConfig :  BaseConfig<Kullanici>
    {
        public override void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Adi).HasMaxLength(15);
            builder.Property(p => p.Adi).IsRequired();
            
            builder.Property(p => p.Soyadi).HasMaxLength(15);
            builder.Property(p => p.Soyadi).IsRequired();
            
            builder.Property(p => p.Tel).HasMaxLength(11);
            builder.Property(p => p.Tel).IsRequired();
            builder.HasIndex(p => p.Tel).IsUnique();
            
            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.Property(p => p.Mail).IsRequired();
            builder.HasIndex(p => p.Mail).IsUnique();

            builder.Property(p => p.Sifre).HasMaxLength(16);
            builder.Property(p => p.Sifre).IsRequired();
        }
    }
}
