using Microsoft.AspNetCore.Mvc;
using kutuphaneApi2.Services;

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

        [HttpGet("ozet")]
        public async Task<IActionResult> GetOzet()
        {
            var sonuc = await _istatistikService.GetOzetAsync();
            return Ok(sonuc);
        }
    }
}