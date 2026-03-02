using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Data;
using kutuphaneApi2.Interfaces;

namespace kutuphaneApi2.Services
{
    public class IstatistikService : IIstatistikService
    {
        private readonly UygulamaDbContext _context;

        public IstatistikService(UygulamaDbContext context)
        {
            _context = context;
        }

        public async Task<IstatistikDto> GetIstatistikAsync()
        {
            return new IstatistikDto
            {
                KitapSayisi = await _context.Kitaplar.CountAsync(),
                YazarSayisi = await _context.Yazarlar.CountAsync(),
                UyeSayisi = await _context.Uyeler.CountAsync(),
                OduncSayisi = await _context.OduncIslemler.CountAsync(x => x.IadeTarihi == null)
            };
        }

        public async Task<IstatistikDto> GetIstatistikAsync()
        {
            return new IstatistikDto
            {
                KitapSayisi = await _context.Kitaplar.CountAsync(),
                YazarSayisi = await _context.Yazarlar.CountAsync(),
                UyeSayisi = await _context.Uyeler.CountAsync(),
                OduncSayisi = await _context.OduncIslemler.CountAsync(x => x.IadeTarihi == null)
            };
        }
    }
}