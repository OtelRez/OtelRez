using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelRez.BL.Managers.Concrete
{
    public class RezervasyonManager(IManager<Rezervasyon> rezervasyonManager, IManager<Oda> odaManager, IManager<OdaTur> odaTurManager) : Manager<Rezervasyon>, IRezervasyonManager
    {
        private readonly IManager<Rezervasyon> _rezervasyonManager = rezervasyonManager;
        private readonly IManager<Oda> _odaManager = odaManager;
        private readonly IManager<OdaTur> _odaTurManager = odaTurManager;

        public bool OdaMusaitMi(int OdaTur, DateOnly GirisTarihi, DateOnly CikisTarihi)
        {
            //int temp = Convert.ToInt32(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            //var kullanici = kullaniciManager.GetAll(p => p.Id == temp).FirstOrDefault();
            //// Odanın daha önce rezerve edilmiş olduğu tarihleri kontrol et
            //var oda = _odaTurManager.GetAll(p => p.Id == OdaTur).ToList();
            //var odalar = _odaManager.GetAll(p => p.OdaTurId == OdaTur).ToList();
            //var rez = _rezervasyonManager.GetAll(p=>p.KullaniciId ==)

            //foreach (var rezervasyon in odalar)
            //{
            //    foreach (var item in oda)
            //    {
            //        // Eğer rezervasyon tarihleri ile kullanıcının girdiği tarih aralığı çakışıyorsa
            //        if (item. < bitisTarihi && rezervasyon.BitisTarihi > baslangicTarihi)
            //        {
            //            return false; // Oda bu tarihlerde rezerve edilmiş, müsait değil
            //        }

            //    }

            //}

            return true; // Oda bu tarihlerde müsait
        }

        public int ToplamTutar(int Tutar, DateOnly GirisTarihi, DateOnly CikisTarihi)
        {
            throw new NotImplementedException();
        }
    }
}
