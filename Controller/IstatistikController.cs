using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Data;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstatistikController : ControllerBase
    {
        private readonly UygulamaDbContext _context;

        public IstatistikController(UygulamaDbContext context)
        {
            _context = context;
        }

        [HttpGet("ozet")]
        public IActionResult GetOzet()
        {
            var ozet = new
            {
                KitapSayisi = _context.Kitaplar.Count(),
                YazarSayisi = _context.Yazarlar.Count(),
                UyeSayisi = _context.Uyeler.Count(),
                DisaridakiKitaplar = _context.OduncIslemler.Count(x => x.IadeTarihi == null)
            };
            return Ok(ozet);
        }
    }
}