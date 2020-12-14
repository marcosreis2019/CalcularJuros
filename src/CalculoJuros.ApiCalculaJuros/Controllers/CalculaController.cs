using CalculoJuros.Core.Models;
using CalculoJuros.Core.Services;
using CalculoJuros.Core.Utilitarios;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculoJuros.ApiCalculaJuros.Controllers
{
    [ApiController]
    public class CalculaController : Controller
    {
        // GET: CalculaJuros
        [HttpGet]
        [Route("/v1/CalculaJuros")]
        public CalculaJuros CalculaJuros(double valorInicial, int meses)
        {
            double juros = 0;

            // Pega a Taxa Juros Padrão do método
            TaxaJuros objTaxaJuros = Utilitario.GetTaxaJurosDefault();

            if (objTaxaJuros != null)
            {
                juros = objTaxaJuros.Juros;
            }

            // Método para consumir a API de TaxaJuros.
            Tuple<double, string> resultadoTaxaJuros = UtilHttpClient.GetTaxaJuros();

            // Pega o juros que retornou da API.
            if (resultadoTaxaJuros.Item1 > 0)
            {
                juros = resultadoTaxaJuros.Item1;
            }

            // Calcula o valor final do juros composto.
            double valorFinal = valorInicial * Math.Pow(1 + juros, meses);

            // Trunca o valor final em duas casas decimais.
            double valorFinalTruncado = Math.Truncate(100 * valorFinal) / 100;

            // Cria a classe de retorno com o resultado.
            CalculaJuros CalculaJuros = new CalculaJuros { JurosCalculado = valorFinalTruncado };

            // Se houve algum erro no método de buscar a taxa de juros
            if (!string.IsNullOrWhiteSpace(resultadoTaxaJuros.Item2))
            {
                string[] erro = resultadoTaxaJuros.Item2.Split("-_-");
                CalculaJuros.Erro = new Erro { Mensagem = erro[0], Detalhes = erro[1] };
            }

            return CalculaJuros;
        }

        // GET: ShowMeTheCode
        [HttpGet]
        [Route("/v1/ShowMeTheCode")]
        public string ShowMeTheCode()
        {
            string urlGithub = string.Empty;

            GitHub objGitHub = Utilitario.GetEnderecoGitHub();

            if (objGitHub != null)
            {
                urlGithub = objGitHub.EnderecoGitProjeto;
            }
            
            return urlGithub;
        }
    }
}