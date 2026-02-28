using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;

namespace kutuphaneApi2.Services
{
    public class IstatistikService : IIstatistikService
    {
        private readonly UygulamaDbContext _context;

        public IstatistikService(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetOzetAsync()
        {
            var ozet = new
            {
                KitapSayisi = await _context.Kitaplar.CountAsync(),
                YazarSayisi = await _context.Yazarlar.CountAsync(),
                UyeSayisi = await _context.Uyeler.CountAsync(),
                DisaridakiKitaplar = await _context.OduncIslemler.CountAsync(x => x.IadeTarihi == null)
            };
            return ozet;
        }
    }
}