using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : ControllerBase
    {
        private readonly UygulamaDbContext _context;
        public KitapController(UygulamaDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kitap>>> GetKitaplar() => await _context.Kitaplar.Include(k => k.Yazar).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Kitap>> PostKitap(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetKitaplar), new { id = kitap.Id }, kitap);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitap(int id, Kitap kitap)
        {
            if (id != kitap.Id) return BadRequest();
            _context.Entry(kitap).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null) return NotFound();
            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}