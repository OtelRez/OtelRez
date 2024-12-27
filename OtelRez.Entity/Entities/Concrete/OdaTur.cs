using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class OdaTur:BaseEntity
    {
        public string TurAdi { get; set; }
        public string TurDetay { get; set; }
        public Int16 Kapasite { get; set; }
        public int Fiyat { get; set; }
        public ICollection<Oda> Odalar { get; set; }
        public string PhotoPath { get; set; }

        public bool Balkon { get; set; }
        public bool WiFi { get; set; } = true;
        public bool Jakuzi { get; set; }
        public bool OdaServisi { get; set; } = true;
        public bool Minibar { get; set; }
    }
}
