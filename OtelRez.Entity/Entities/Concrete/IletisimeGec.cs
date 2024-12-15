using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class IletisimeGec : BaseEntity
    {
        public string Adi { get; set; }
        public string Mail { get; set; }
        public string Konu { get; set; }
        public string Mesaj { get; set; }
    }
}
