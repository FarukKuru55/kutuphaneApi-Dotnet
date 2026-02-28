using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public interface IOduncIslemService
    {
        Task<IEnumerable<OduncIslem>> TumIslemleriGetirAsync();
        Task<string> OduncVerAsync(OduncIslem islem);
        Task<string> IadeAlAsync(int id);
    }
}