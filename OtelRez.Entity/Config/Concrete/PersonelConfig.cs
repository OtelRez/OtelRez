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
            builder.Property(p => p.IzinHakki).HasDefaultValue(30);

            builder.Property(p => p.PersonelMeslekId).IsRequired();
            builder.Property(p => p.Maas).IsRequired();

            builder.HasOne(p => p.PersonelMeslek)
               .WithMany(p => p.Personeller)
               .HasForeignKey(p => p.PersonelMeslekId);

            builder.HasOne(p => p.PersonelGiris)
                .WithOne(p => p.Personel)
                .HasForeignKey<PersonelGiris>(p => p.PersonelId);

            builder.HasOne(p => p.Role)
                .WithMany(p => p.Personeller)
                .HasForeignKey(p => p.RoleId);

            builder.HasData(new Personel { Id = 1, Adi = "Ahmet", Soyadi = "Ak", IzinHakki = 30, PersonelMeslekId = 1, RoleId = 1, Maas = 50000 });
            builder.HasData(new Personel { Id = 2, Adi = "Büşra", Soyadi = "Aksoy", IzinHakki = 20, PersonelMeslekId = 2, RoleId = 2, Maas = 28000 });
            builder.HasData(new Personel { Id = 3, Adi = "Betüş", Soyadi = "Yılmaz", IzinHakki = 20 ,PersonelMeslekId = 3, Maas = 35000 });
        }
    }
}
