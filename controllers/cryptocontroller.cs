using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AggregatorAPI.Services;
using Microsoft.AspNetCore.Http.Connections;
using System.Reflection.Metadata.Ecma335;

namespace AggregatorAPI.Controllers
{
    [ApiController]
    [Route("api/v1/crypto")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoService _cryptoService;

        public CryptoController(ICryptoService cryptoService)  
        {
            _cryptoService = cryptoService;
        }

        [HttpGet("bitcoin")]
        public async Task<IActionResult> GetBitcoinPrice()
        {
            var price = await _cryptoService.GetBitcoinPriceAsync();  
            return Ok(new { BitcoinPriceUSD = price });
        }

        [HttpGet("ethereum")]
        public async Task<IActionResult> GetEthereumPrice()
        {
            var price = await _cryptoService.
            GetEthereumPriceAsync();
            return Ok(new { EthereumPrice = price});
        }

        [HttpGet("gold")]
        public async Task<IActionResult> GetGoldPrice()
        {
            var price = await _cryptoService.GetGoldPriceAsync();
            return Ok(new { GoldPrice = price });
        }

        [HttpGet("silver")]
        public async Task<IActionResult> GetSilverPrice()
        {
            var price = await _cryptoService.GetSilverPriceAsync();
            return Ok(new { SilverPrice = price});
        }
    }
}