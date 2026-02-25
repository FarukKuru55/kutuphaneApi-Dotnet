using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UyeController : ControllerBase
    {
        private readonly UygulamaDbContext _context;
        public UyeController(UygulamaDbContext context) { _context = context; }

        // 1. ÜYELERİ LİSTELE
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uye>>> GetUyeler() => await _context.Uyeler.ToListAsync();

        // 2. YENİ ÜYE EKLE
        [HttpPost]
        public async Task<ActionResult<Uye>> PostUye(Uye uye)
        {
            _context.Uyeler.Add(uye);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUyeler), new { id = uye.Id }, uye);
        }

        // 3. ÜYE GÜNCELLE
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUye(int id, Uye uye)
        {
            if (id != uye.Id) return BadRequest();
            _context.Entry(uye).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 4. ÜYE SİL
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUye(int id)
        {
            var uye = await _context.Uyeler.FindAsync(id);
            if (uye == null) return NotFound();
            _context.Uyeler.Remove(uye);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}