

using Microsoft.AspNetCore.Mvc;

namespace Tubes.API.Controllers
{
    public class TransaksiController : Controller
    {
        private static readonly List<string> _listTransaksi = new List<string>();



        [HttpGet]
        public IActionResult GetTransaksi()
        {
            return Ok(_listTransaksi);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaksiById(int id)
        {
            if (id < 0 || id >= _listTransaksi.Count)
            {
                return NotFound();
            }
            return Ok(_listTransaksi[id]);
        }
    }
}
