using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Services;
using kutuphaneApi2.Interfaces;

namespace kutuphaneApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IstatistikController : ControllerBase
    {
        private readonly IIstatistikService _istatistikService;

        public IstatistikController(IIstatistikService istatistikService)
        {
            _istatistikService = istatistikService;
        }

        [HttpGet]
        public async Task<IActionResult> GetIstatistik()
        {
       
            var sonuc = await _istatistikService.GetIstatistikAsync();
            return Ok(sonuc);
        }
    }
}