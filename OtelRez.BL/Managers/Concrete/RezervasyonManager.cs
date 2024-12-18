using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            rez.ToplamTutar = ToplamTutar(TurId, rez.Giris, rez.Cikis);

            _context.Rezervasyonlar.Add(rez);

            // Odanın müsaitlik durumunu güncelle
            await _context.SaveChangesAsync();

            return true;
        }

        public int ToplamTutar(int OdaId, DateOnly GirisTarihi, DateOnly CikisTarihi)
        {
            // Giriş ve çıkış tarihi arasındaki farkı gün cinsinden hesapla
            int gunSayisi = (CikisTarihi.DayNumber - GirisTarihi.DayNumber);

            // Odanın fiyatını OdaTürleri tablosundan al
            var oda = _context.Odalar
                .Include(o => o.OdaTur)
                .FirstOrDefault(o => o.Id == OdaId);

            if (oda == null || gunSayisi <= 0)
                throw new ArgumentException("Geçersiz Oda veya Tarih bilgisi!");

            int fiyat = oda.OdaTur.Fiyat;

            // Toplam tutarı hesapla
            int toplamTutar = fiyat * gunSayisi;

            return toplamTutar;
        }
    }
}
