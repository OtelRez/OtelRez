using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class PersonelMeslek : BaseEntity
    {
        public string Meslek {  get; set; }
        public int Maas { get; set; }
        public ICollection<Personel> Personeller { get; set; }

    }
}
