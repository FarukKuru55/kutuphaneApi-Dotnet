using Microsoft.EntityFrameworkCore;
using kutuphaneApi2.Models;

namespace kutuphaneApi2.Data
{
    public class UygulamaDbContext : DbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options)
        {
        }

        // Veritabanında oluşacak tablo isimleri:
        public DbSet<Yazar> Yazarlar { get; set; }
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<OduncIslem> OduncIslemler { get; set; }
    }
}