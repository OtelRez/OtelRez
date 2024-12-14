using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Personel : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int IzinHakki { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
        public int PersonelMeslekId { get; set; }
        public PersonelMeslek PersonelMeslek { get; set; }
        public PersonelGiris PersonelGiris { get; set; }
    }
}
