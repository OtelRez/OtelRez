using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Oda:BaseEntity
    {
        public string OdaNumarasi { get; set; }
        public ICollection<OdaTur> Turler { get; set; }
        public int Fiyat { get; set; }
        public bool Musait { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlar { get; set; }

    }
}
