using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OduncIslemController : ControllerBase
    {
        private readonly UygulamaDbContext _context;
        public OduncIslemController(UygulamaDbContext context) { _context = context; }

        // 1. TÜM İŞLEMLERİ LİSTELE (Paneldeki tablo için)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OduncIslem>>> GetIslemler()
        {
            return await _context.OduncIslemler
                .Include(i => i.Kitap)
                .Include(i => i.Uye)
                .ToListAsync();
        }

        // 2. ÖDÜNÇ VER (POST)
        [HttpPost("odunc-ver")]
        public async Task<IActionResult> OduncVer(OduncIslem islem)
        {
            // Kitabı bul
            var kitap = await _context.Kitaplar.FindAsync(islem.KitapId);
            if (kitap == null || !kitap.MevcutMu) return BadRequest("Kitap şu an müsait değil!");

            // Kitabı dışarıda olarak işaretle
            kitap.MevcutMu = false;

            islem.VerilisTarihi = DateTime.Now;
            islem.IadeTarihi = null; // Henüz iade edilmedi

            _context.OduncIslemler.Add(islem);
            await _context.SaveChangesAsync();

            return Ok(new { mesaj = "Kitap başarıyla ödünç verildi." });
        }

        // 3. İADE AL (PUT)
        [HttpPut("iade-al/{id}")]
        public async Task<IActionResult> IadeAl(int id)
        {
            var islem = await _context.OduncIslemler.Include(i => i.Kitap).FirstOrDefaultAsync(x => x.Id == id);
            if (islem == null) return NotFound();

            // Kitabı tekrar müsait yap
            if (islem.Kitap != null) islem.Kitap.MevcutMu = true;

            islem.IadeTarihi = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok(new { mesaj = "Kitap iade alındı." });
        }
    }
}