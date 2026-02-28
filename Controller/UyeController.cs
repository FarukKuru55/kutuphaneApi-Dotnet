using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Models;
using kutuphaneApi2.Services; 

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyeController : ControllerBase
    {
        // SERVICE 
        private readonly IUyeService _uyeService;

        public UyeController(IUyeService uyeService)
        {
            _uyeService = uyeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uye>>> GetUyeler()
        {
            var uyeler = await _uyeService.TumUyeleriGetirAsync();
            return Ok(uyeler);
        }

        [HttpPost]
        public async Task<ActionResult<Uye>> PostUye(Uye uye)
        {
            await _uyeService.UyeEkleAsync(uye);
            return CreatedAtAction(nameof(GetUyeler), new { id = uye.Id }, uye);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUye(int id, Uye uye)
        {
            if (id != uye.Id) return BadRequest();
            await _uyeService.UyeGuncelleAsync(uye);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUye(int id)
        {
            await _uyeService.UyeSilAsync(id);
            return NoContent();
        }
    }
}