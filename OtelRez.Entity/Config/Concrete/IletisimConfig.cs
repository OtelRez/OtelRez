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
    public class IletisimConfig : BaseConfig<Iletisim>
    {
        public override void Configure(EntityTypeBuilder<Iletisim> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Tel).HasMaxLength(15);
            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.Property(p => p.Adres).HasMaxLength(500);

            builder.HasData(new Iletisim() { Id = 1, Tel="0212 568 93 96", Mail= "istkafullkata@gmail.com", Adres="İstanbul,Beşiktaş"});
        }
    }
}
