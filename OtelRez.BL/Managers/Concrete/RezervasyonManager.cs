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
    public class RezervasyonManager
    {
        private readonly AppDbContext _context= new AppDbContext(new DbContextOptionsBuilder<AppDbContext>()
        .UseSqlServer("Server=.;Database=OtelRezDb;Trusted_Connection=True;")
        .Options);

        public async Task<Oda> OdaMusaitMi(int OdaTurId, DateOnly GirisTarihi, DateOnly CikisTarihi)
        {
           var musaitOda = await _context.Odalar.Where(p=>p.OdaTurId==OdaTurId).FirstOrDefaultAsync
                (p=> !_context.Rezervasyonlar.Any(res=>res.OdaId==p.Id && 
                (
                    (GirisTarihi >= res.Giris && GirisTarihi < res.Cikis) ||
                    (CikisTarihi > res.Giris && CikisTarihi <= res.Cikis) ||
                    (GirisTarihi <= res.Giris && CikisTarihi >= res.Cikis)
                )
                ));

            return musaitOda;
        }

        public async Task<bool> RezervasyonOlustur(int TurId, Rezervasyon rez)
        {
            // Uygun bir oda bul
            var uygunOda = await OdaMusaitMi(TurId, rez.Giris, rez.Cikis);
            if (uygunOda == null)
            {
                return false; // Uygun oda bulunamadı
            }

            // Rezervasyon işlemini tamamla
            rez.OdaId = uygunOda.Id;
            _context.Rezervasyonlar.Add(rez);

            // Odanın müsaitlik durumunu güncelle
            await _context.SaveChangesAsync();

            return true;
        }


        public int ToplamTutar(int Tutar, DateOnly GirisTarihi, DateOnly CikisTarihi)
        {
            throw new NotImplementedException();
        }
    }
}
