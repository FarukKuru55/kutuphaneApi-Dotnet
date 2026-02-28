using kutuphaneApi2.Models;

namespace kutuphaneApi2.Services
{
    public interface IYazarService
    {
        Task<IEnumerable<Yazar>> TumYazarlariGetirAsync();
        Task<Yazar?> YazarGetirByIdAsync(int id);
        Task YazarEkleAsync(Yazar yazar);
        Task YazarGuncelleAsync(Yazar yazar);
        Task YazarSilAsync(int id);
    }
}