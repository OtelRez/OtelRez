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
    public class RoleConfig : BaseConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.RoleAdi).HasMaxLength(20);
            builder.HasIndex(p => p.RoleAdi).IsUnique();
            builder.Property(p=>p.RoleAdi).IsRequired();

            builder.HasData(new Role() { Id = 1, RoleAdi = "Yonetici" });
            builder.HasData(new Role() { Id = 2, RoleAdi = "Resepsiyonist" });
            builder.HasData(new Role() { Id = 3, RoleAdi = "Kullanici" });

            //builder.HasData(
            //    new Role() { RoleAdi = "Yonetici" },
            //    new Role() { RoleAdi = "Resepsiyonist" },
            //    new Role() { RoleAdi = "Kullanici" }

            //    );

        }
    }
}
