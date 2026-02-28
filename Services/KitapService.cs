using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public class KitapService : IKitapService
    {
        private readonly UygulamaDbContext _context;

        public KitapService(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kitap>> TumKitaplariGetirAsync()
        {
            return await _context.Kitaplar.Include(k => k.Yazar).ToListAsync();
        }

        public async Task<Kitap?> KitapGetirByIdAsync(int id)
        {
            return await _context.Kitaplar.Include(k => k.Yazar).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task KitapEkleAsync(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            await _context.SaveChangesAsync();
        }

        public async Task KitapGuncelleAsync(Kitap kitap)
        {
            _context.Entry(kitap).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task KitapSilAsync(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                await _context.SaveChangesAsync();
            }
        }
    }
}