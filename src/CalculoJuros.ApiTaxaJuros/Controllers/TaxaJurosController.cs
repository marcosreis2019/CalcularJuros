using CalculoJuros.Core.Models;
using CalculoJuros.Core.Utilitarios;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.ApiTaxaJuros.Controllers
{
    [ApiController]
    public class TaxaJurosController : Controller
    {
        // GET: TaxaJuros
        [HttpGet]
        [Route("/v1/TaxaJuros")]
        public TaxaJuros TaxaJuros()
        {
            TaxaJuros objTaxaJuros = Utilitario.GetTaxaJurosDefault();

            return objTaxaJuros;
        }
    }
}