using kutuphaneApi2.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace kutuphaneApi2.Services
{
    public interface IUyeService
    {
        Task<IEnumerable<Uye>> TumUyeleriGetirAsync();
        Task<Uye?> UyeGetirByIdAsync(int id); // Nullable yaptık
        Task UyeEkleAsync(Uye uye);
        Task UyeGuncelleAsync(Uye uye);
        Task UyeSilAsync(int id);
    }
}