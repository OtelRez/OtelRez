using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Role : BaseEntity
    {
        public string RoleAdi { get; set; }
        public ICollection<Kullanici> Kullanicilar { get; set; }
        public ICollection<Personel> Personeller { get; set; }
    }
}
