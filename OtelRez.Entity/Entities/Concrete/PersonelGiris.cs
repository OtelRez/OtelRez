using OtelRez.Entity.Entities.Abstract;
using OtinternalEntity.Entitieste;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class PersonelGiris : BaseEntity
    {
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
    }
}
