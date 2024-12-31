using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using OtelRez.BL.Managers.Abstract;
using OtelRez.Entity.Entities.Concrete;
using OtelRez.MVC.Areas.Admin.Models.VMs.Admin;
using SixLabors.ImageSharp.Processing;

namespace OtelRez.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OdaController(IManager<OdaTur> odaTurManager, INotyfService notyfService) : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OdaGuncelle(int Id)
        {
            var oda = odaTurManager.GetById(Id);
            var model = new OdaGuncelleVM
            {
                OdaAdi = oda.TurAdi,
                Fiyat = oda.Fiyat,
                PhotoPath = oda.PhotoPath
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> OdaGuncelle(OdaGuncelleVM model)
        {
            if (ModelState.IsValid)
            {
                // Mevcut oda bilgisini veritabanından al
                var existingOda = odaTurManager.GetById(model.Id);
                if (existingOda == null)
                {
                    return NotFound();
                }

                // Güncellenen bilgileri mevcut oda kaydına ata
                existingOda.TurAdi = model.OdaAdi;
                existingOda.Fiyat = model.Fiyat;

                // Fotoğraf dosyasını yükle
                if (model.PhotoPathFile != null)
                {
                    var uploadsFolderPath = Path.Combine("wwwroot/OtelTemp/assets/img/rooms");
                    var fileName = Path.GetFileNameWithoutExtension(model.PhotoPathFile.FileName);
                    var fileExtension = Path.GetExtension(model.PhotoPathFile.FileName);
                    var filePath = Path.Combine(uploadsFolderPath, fileName + fileExtension);

                    // Hedef klasörü oluştur
                    if (!Directory.Exists(uploadsFolderPath))
                    {
                        Directory.CreateDirectory(uploadsFolderPath);
                    }

                    using (var stream = new MemoryStream())
                    {
                        await model.PhotoPathFile.CopyToAsync(stream); // Dosyayı belleğe yükle
                        stream.Position = 0; // Belleğin başlangıcına dön

                        // ImageSharp kullanarak resmi yükle
                        using (var image = await SixLabors.ImageSharp.Image.LoadAsync(stream))
                        {
                            image.Mutate(x => x.Resize(360, 372)); // Resmi yeniden boyutlandır
                            stream.Position = 0; // Belleğin başlangıcına dön
                        }

                        // Dosyayı fiziksel olarak kaydet
                        await System.IO.File.WriteAllBytesAsync(filePath, stream.ToArray());
                    }

                    existingOda.PhotoPath = "/OtelTemp/assets/img/rooms/" + fileName + fileExtension;
                }
                else if (!string.IsNullOrEmpty(existingOda.PhotoPath))
                {
                    model.PhotoPath = existingOda.PhotoPath;
                }

                // Veritabanında değişiklikleri kaydet
                odaTurManager.Update(existingOda);
                notyfService.Success("İşlem başarılı.");

                // Başarılı güncelleme sonrası bir sayfaya yönlendirme
                return RedirectToAction("Index", "Oda"); // Oda listesi sayfasına yönlendirme
            }

            // Model doğrulama hatası varsa aynı sayfayı tekrar göster
            return View(model);
        }
    }
}
