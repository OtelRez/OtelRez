﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OtelRez.Entity.Config.Abstract;
using OtelRez.Entity.Entities.Abstract;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Config.Concrete
{
    public class IletisimeGecConfig : BaseConfig<IletisimeGec>
    {
        public override void Configure(EntityTypeBuilder<IletisimeGec> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Adi).HasMaxLength(50);
            builder.Property(p => p.Mail).HasMaxLength(50);
            builder.Property(p => p.Konu).HasMaxLength(100);
            builder.Property(p => p.Mesaj).HasMaxLength(500);
        }
    }
}
