using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Managers.Abstract
{
    public interface IRezervasyonManager : IManager<Rezervasyon>
    {
        public bool OdaMusaitMi(int OdaTur, DateOnly GirisTarihi, DateOnly CikisTarihi);
        public int ToplamTutar(int Tutar, DateOnly GirisTarihi, DateOnly CikisTarihi);
    }
}
