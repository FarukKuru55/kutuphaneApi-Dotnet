using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarController : ControllerBase
    {
        private readonly UygulamaDbContext _context;
        public YazarController(UygulamaDbContext context) { _context = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Yazar>>> GetYazarlar() => await _context.Yazarlar.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Yazar>> PostYazar(Yazar yazar)
        {
            _context.Yazarlar.Add(yazar);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetYazarlar), new { id = yazar.Id }, yazar);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutYazar(int id, Yazar yazar)
        {
            if (id != yazar.Id) return BadRequest();
            _context.Entry(yazar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteYazar(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar == null) return NotFound();
            _context.Yazarlar.Remove(yazar);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}