using kutuphaneApi2.Models;

namespace kutuphaneApi2.Interfaces
{
    public interface IOduncIslemService
    {
        Task<IEnumerable<OduncIslem>> TumIslemleriGetirAsync();
        Task<string> OduncVerAsync(OduncIslem islem);
        Task<string> IadeAlAsync(int id);
    }
}