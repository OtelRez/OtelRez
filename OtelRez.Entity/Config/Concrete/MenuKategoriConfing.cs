using OtelRez.Entity.Config.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class MenuKategoriConfing : BaseConfig<MenuKategori>
    {
        public override void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<MenuKategori> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.KategoriAdi).HasMaxLength(50);
            builder.Property(p => p.KategoriAdi).IsRequired();
            builder.HasIndex(p => p.KategoriAdi).IsUnique();

            builder.HasData(new MenuKategori() { Id = 1, KategoriAdi = "Kahvaltı" });
            builder.HasData(new MenuKategori() { Id = 2, KategoriAdi = "Atıştırmalık" });
            builder.HasData(new MenuKategori() { Id = 3, KategoriAdi = "Ana Yemek" });
            builder.HasData(new MenuKategori() { Id = 4, KategoriAdi = "Tatlı" });
            builder.HasData(new MenuKategori() { Id = 5, KategoriAdi = "İçecek" });
        }
    }
}
