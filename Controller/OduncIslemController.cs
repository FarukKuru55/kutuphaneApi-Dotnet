using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Models;
using kutuphaneApi2.Services;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OduncIslemController : ControllerBase
    {
        private readonly IOduncIslemService _oduncIslemService;

        public OduncIslemController(IOduncIslemService oduncIslemService)
        {
            _oduncIslemService = oduncIslemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OduncIslem>>> GetIslemler()
        {
            var islemler = await _oduncIslemService.TumIslemleriGetirAsync();
            return Ok(islemler);
        }

        [HttpPost("odunc-ver")]
        public async Task<IActionResult> OduncVer(OduncIslem islem)
        {
            var sonuc = await _oduncIslemService.OduncVerAsync(islem);

            if (sonuc.Contains("değil"))
                return BadRequest(new { mesaj = sonuc });

            return Ok(new { mesaj = sonuc });
        }

        [HttpPut("iade-al/{id}")]
        public async Task<IActionResult> IadeAl(int id)
        {
            var sonuc = await _oduncIslemService.IadeAlAsync(id);

            if (sonuc.Contains("bulunamadı"))
                return NotFound(new { mesaj = sonuc });

            return Ok(new { mesaj = sonuc });
        }
    }
}