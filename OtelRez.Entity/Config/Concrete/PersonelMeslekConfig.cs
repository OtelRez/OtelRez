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
    public class PersonelMeslekConfig : BaseConfig<PersonelMeslek>
    {
        public override void Configure(EntityTypeBuilder<PersonelMeslek> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Meslek).HasMaxLength(20);
            builder.Property(p => p.Meslek).IsRequired();
            builder.HasIndex(p => p.Meslek).IsUnique();

            builder.Property(p => p.Maas).IsRequired();

            builder.HasData(new PersonelMeslek() { Id = 1, Meslek = "Yönetici", Maas = 50000 });
            builder.HasData(new PersonelMeslek() { Id = 2, Meslek = "Resepsiyonist", Maas = 18002 });
            builder.HasData(new PersonelMeslek() { Id =3, Meslek = "Aşçı", Maas = 25000 });
        }
    }
}
