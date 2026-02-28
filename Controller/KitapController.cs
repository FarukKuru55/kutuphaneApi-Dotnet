using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Models;
using kutuphaneApi2.Services;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private readonly IKitapService _kitapService;

        public KitapController(IKitapService kitapService)
        {
            _kitapService = kitapService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetKitaplar()
        {
            var kitaplar = await _kitapService.TumKitaplariGetirAsync();
            return Ok(kitaplar);
        }

        [HttpPost]
        public async Task<ActionResult<Kitap>> PostKitap(Kitap kitap)
        {
            await _kitapService.KitapEkleAsync(kitap);
            return CreatedAtAction(nameof(GetKitaplar), new { id = kitap.Id }, kitap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitap(int id, Kitap kitap)
        {
            if (id != kitap.Id) return BadRequest();
            await _kitapService.KitapGuncelleAsync(kitap);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitap(int id)
        {
            await _kitapService.KitapSilAsync(id);
            return NoContent();
        }
    }
}