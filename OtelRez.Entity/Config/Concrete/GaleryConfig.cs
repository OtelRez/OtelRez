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
    public class GaleryConfig : BaseConfig<Galery>
    {
        public override void Configure(EntityTypeBuilder<Galery> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.PhotoPath).IsRequired();

            builder.HasData(new Galery() { Id = 1, PhotoPath = "/OtelTemp/assets/img/rooms/room1.jpg",IsOda=true });
            builder.HasData(new Galery() { Id = 2, PhotoPath = "/OtelTemp/assets/img/rooms/room2.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 3, PhotoPath = "/OtelTemp/assets/img/rooms/room3.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 4, PhotoPath = "/OtelTemp/assets/img/rooms/room4.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 5, PhotoPath = "/OtelTemp/assets/img/rooms/room5.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 6, PhotoPath = "/OtelTemp/assets/img/gallery/gallery1.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 7, PhotoPath = "/OtelTemp/assets/img/gallery/gallery2.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 8, PhotoPath = "/OtelTemp/assets/img/gallery/gallery3.jpg", IsOda = true });
            builder.HasData(new Galery() { Id = 9, PhotoPath = "/OtelTemp/assets/img/dining/dining-img.jpg", IsRestorant = true });
            builder.HasData(new Galery() { Id = 10, PhotoPath = "/OtelTemp/assets/img/dining/dining-img2.jpg", IsPool = true });
        }
    }
}
