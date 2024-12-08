using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace OtinternalEntity.Entitieste
{
    public class Personel : BaseEntity
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int IzinHakki { get; set; }
    }
}
