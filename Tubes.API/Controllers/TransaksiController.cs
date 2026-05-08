using Tubes.Core;

using Microsoft.AspNetCore.Mvc;
namespace Tubes.API.Controllers
{

    [ApiController]
    [Route("api/Transaksi")]
    public class TransaksiController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetTransaksi()
        {
            await Transaksi.LoadTransaksi();
            var result = Transaksi.ListTransaksi;

            if (result.Count == 0) return Ok("The file was found, but the dictionary is empty.");
            return Ok(Transaksi.ListTransaksi);
        }

        [HttpGet("{kodeTransaksi}")]
        public async Task<IActionResult> GetTransaksiByKode(string kodeTransaksi)
        {
            await Transaksi.LoadTransaksi();
            var result = Transaksi.ListTransaksi;
            if (!result.TryGetValue(kodeTransaksi, out var transaksi))
            {
                return NotFound($"Key {kodeTransaksi} was not found.");
            }

            return Ok(transaksi);
        }

    }
}
