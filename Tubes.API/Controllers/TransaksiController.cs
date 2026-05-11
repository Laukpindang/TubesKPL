using Tubes.Core;

using Microsoft.AspNetCore.Mvc;
namespace Tubes.API.Controllers
{

    [ApiController]
    [Route("api/Transaksi")]
    public class TransaksiController : Controller
    {

        [HttpGet]
        public IActionResult GetTransaksi()
        {
            Transaksi.LoadTransaksi();
            var result = Transaksi.ListTransaksi;

            return Ok(Transaksi.ListTransaksi);
        }

        [HttpGet("{kodeTransaksi}")]
        public IActionResult GetTransaksiByKode(string kodeTransaksi)
        {
            Transaksi.LoadTransaksi();
            var result = Transaksi.ListTransaksi;
            if (!result.TryGetValue(kodeTransaksi, out var transaksi))
            {
                return NotFound($"Key {kodeTransaksi} was not found.");
            }

            return Ok(transaksi);
        }

    }
}
