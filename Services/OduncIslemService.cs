using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public class OduncIslemService : IOduncIslemService
    {
        private readonly UygulamaDbContext _context;

        public OduncIslemService(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OduncIslem>> TumIslemleriGetirAsync()
        {
            return await _context.OduncIslemler
                .Include(i => i.Kitap)
                .Include(i => i.Uye)
                .Where(i => i.IadeTarihi == null)
                .ToListAsync();
        }

        public async Task<string> OduncVerAsync(OduncIslem islem)
        {
            var kitap = await _context.Kitaplar.FindAsync(islem.KitapId);

            if (kitap == null || !kitap.MevcutMu)
                return "Kitap şu an müsait değil!";

            kitap.MevcutMu = false; // Kitabı dışarıda olarak işaretle  
            islem.VerilisTarihi = DateTime.Now;
            islem.IadeTarihi = null;

            _context.OduncIslemler.Add(islem);
            await _context.SaveChangesAsync();

            return "Kitap başarıyla ödünç verildi.";
        }

        public async Task<string> IadeAlAsync(int id)
        {
            var islem = await _context.OduncIslemler
                .Include(i => i.Kitap)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (islem == null) return "İşlem kaydı bulunamadı!";

            if (islem.Kitap != null)
                islem.Kitap.MevcutMu = true; // Kitabı tekrar müsait yap

            islem.IadeTarihi = DateTime.Now;
            await _context.SaveChangesAsync();

            return "Kitap iade alındı.";
        }
    }
}