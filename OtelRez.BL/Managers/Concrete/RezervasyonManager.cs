using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OtelRez.BL.Managers.Abstract;
using OtelRez.DAL.DbContexts;
using OtelRez.DAL.Repositories.Concrete;
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
        private readonly INotyfService _notyfService;

        private readonly string _connectionString;

        private readonly IManager<OdaTur> odaTurManager;
        private readonly IManager<Rezervasyon> rezervasyonManager;

        private readonly Repository<OdaTur> _odaTurRepository;
        private readonly Repository<Oda> _odaRepository;
        private readonly Repository<Rezervasyon> _rezervasyonRepository;

        public RezervasyonManager()
        {
            _odaTurRepository = new Repository<OdaTur>();
            _odaRepository = new Repository<Oda>();
            _rezervasyonRepository = new Repository<Rezervasyon>();
        }

        // Oda Türlerini getir
        public async Task<List<OdaTur>> GetOdaTurleriAsync()
        {
            return await Task.Run(() => _odaTurRepository.GetAll());
        }

        public async Task<Oda> OdaMusaitMi(int OdaTurId, DateTime GirisTarihi, DateTime CikisTarihi)
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

        public async Task<bool> RezervasyonOlustur(int TurId, Rezervasyon rez, int KullaniciId)
        {
            if(rez.Giris >= rez.Cikis)
            {
                _notyfService.Warning("Giriş tarihi çıkış tarihinden büyük olamaz!");
                return false;
            }
            // Uygun bir oda bul
            var uygunOda = await OdaMusaitMi(TurId, rez.Giris, rez.Cikis);
            if (uygunOda == null)
            {
                return false; // Uygun oda bulunamadı
            }

            // Rezervasyon işlemini tamamla
            rez.OdaId = uygunOda.Id;

            rez.ToplamTutar = ToplamTutar(uygunOda.OdaTurId, rez.Giris, rez.Cikis);
            rez.KullaniciId = KullaniciId;

            _context.Rezervasyonlar.Add(rez);

            // Odanın müsaitlik durumunu güncelle
            await _context.SaveChangesAsync();

            return true;
        }

		public int ToplamTutar(int OdaTurId, DateTime GirisTarihi, DateTime CikisTarihi)
		{
			// Giriş ve çıkış tarihi arasındaki farkı gün cinsinden hesapla
			int gunSayisi = (CikisTarihi - GirisTarihi).Days;

			// Odanın fiyatını OdaTürleri tablosundan al
			var oda = _context.OdaTurleri
				.Include(o => o.Odalar)
				.FirstOrDefault(o => o.Id == OdaTurId);

			if (oda == null || gunSayisi <= 0)
				throw new ArgumentException("Geçersiz Oda veya Tarih bilgisi!");

			int fiyat = oda.Fiyat;

			// Toplam tutarı hesapla
			int toplamTutar = fiyat * gunSayisi;

			return toplamTutar;
		}

        public async Task<OdaTur> GetOdaTurByIdAsync(int odaTurId)
        {
            return await _context.OdaTurleri
                .FirstOrDefaultAsync(o => o.Id == odaTurId);
        }
    }
}
