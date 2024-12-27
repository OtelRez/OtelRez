using OtelRez.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.Entity.Entities.Concrete
{
    public class Galery : BaseEntity
    {
        public string PhotoPath { get; set; }
        public bool IsOda { get; set; }=false;
        public bool IsRestorant { get; set; }=false;
        public bool IsPool { get; set; } = false;
    }
}
