using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Menu : BaseEntity
    {
        public string UrunAdi { get; set; }
        public string? UrunAciklama { get; set; }
        public int Fiyat { get; set; }
        public int MenuKategoriId { get; set; }
        public MenuKategori MenuKategori { get; set; }
    }
}
