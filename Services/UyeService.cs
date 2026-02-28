using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public class UyeService : IUyeService
    {
        private readonly UygulamaDbContext _context;
        public UyeService(UygulamaDbContext context) { _context = context; }

        public async Task<IEnumerable<Uye>> TumUyeleriGetirAsync() => await _context.Uyeler.ToListAsync();

        public async Task<Uye?> UyeGetirByIdAsync(int id) => await _context.Uyeler.FindAsync(id);

        public async Task UyeEkleAsync(Uye uye)
        {
            // Business Logic Örneği: Telefon numarası zaten var mı kontrol et
            var varMi = await _context.Uyeler.AnyAsync(x => x.Telefon == uye.Telefon);
            if (varMi) throw new Exception("Bu telefon numarasıyla kayıtlı bir üye zaten var!");

            _context.Uyeler.Add(uye);
            await _context.SaveChangesAsync();
        }

        public async Task UyeGuncelleAsync(Uye uye)
        {
            _context.Entry(uye).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UyeSilAsync(int id)
        {
            var uye = await _context.Uyeler.FindAsync(id);
            if (uye != null)
            {
                _context.Uyeler.Remove(uye);
                await _context.SaveChangesAsync();
            }
        }
    }
}