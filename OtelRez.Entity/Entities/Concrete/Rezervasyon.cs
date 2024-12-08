using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Rezervasyon:BaseEntity
    {
        public DateTime Giris { get; set; }
        public DateTime Cikis { get; set; }
        public ICollection<Oda> Odalar { get; set; }
        public ICollection<Kullanici> Kullaniciler { get; set; }

    }
}
