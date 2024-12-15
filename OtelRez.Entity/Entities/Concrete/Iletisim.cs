using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Iletisim : BaseEntity
    {
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Adres { get; set; }
    }
}
