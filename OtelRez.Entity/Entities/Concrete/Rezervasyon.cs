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
        public DateTime CreateTime { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }

        public int OdaId { get; set; }
        public Oda Oda { get; set; }
    }
}
