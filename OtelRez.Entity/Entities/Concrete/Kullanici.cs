using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Kullanici:BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateOnly? DogumTarihi { get; set; }
        public ICollection<Rezervasyon> Rezervasyonlar { get; set; }


    }
}
