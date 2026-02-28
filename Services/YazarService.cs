using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public class YazarService : IYazarService
    {
        private readonly UygulamaDbContext _context;

        public YazarService(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Yazar>> TumYazarlariGetirAsync()
        {
            return await _context.Yazarlar.ToListAsync();
        }

        public async Task<Yazar?> YazarGetirByIdAsync(int id)
        {
            return await _context.Yazarlar.FindAsync(id);
        }

        public async Task YazarEkleAsync(Yazar yazar)
        {
            _context.Yazarlar.Add(yazar);
            await _context.SaveChangesAsync();
        }

        public async Task YazarGuncelleAsync(Yazar yazar)
        {
            _context.Entry(yazar).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task YazarSilAsync(int id)
        {
            var yazar = await _context.Yazarlar.FindAsync(id);
            if (yazar != null)
            {
                _context.Yazarlar.Remove(yazar);
                await _context.SaveChangesAsync();
            }
        }
    }
}