using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Models;
using kutuphaneApi2.Services;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private readonly IYazarService _yazarService;

        public YazarController(IYazarService yazarService)
        {
            _yazarService = yazarService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yazar>>> GetYazarlar()
        {
            var yazarlar = await _yazarService.TumYazarlariGetirAsync();
            return Ok(yazarlar);
        }

        [HttpPost]
        public async Task<ActionResult<Yazar>> PostYazar(Yazar yazar)
        {
            await _yazarService.YazarEkleAsync(yazar);
            return CreatedAtAction(nameof(GetYazarlar), new { id = yazar.Id }, yazar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYazar(int id, Yazar yazar)
        {
            if (id != yazar.Id) return BadRequest();
            await _yazarService.YazarGuncelleAsync(yazar);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYazar(int id)
        {
            await _yazarService.YazarSilAsync(id);
            return NoContent();
        }
    }
}