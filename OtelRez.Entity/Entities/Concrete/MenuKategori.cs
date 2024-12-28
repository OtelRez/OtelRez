using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class MenuKategori : BaseEntity
    {
        public string KategoriAdi { get; set; }
        public ICollection<Menu> Menu { get; set; }
    }
}
