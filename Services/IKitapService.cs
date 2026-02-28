using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public interface IKitapService
    {
        Task<IEnumerable<Kitap>> TumKitaplariGetirAsync();
        Task<Kitap?> KitapGetirByIdAsync(int id);
        Task KitapEkleAsync(Kitap kitap);
        Task KitapGuncelleAsync(Kitap kitap);
        Task KitapSilAsync(int id);
    }
}