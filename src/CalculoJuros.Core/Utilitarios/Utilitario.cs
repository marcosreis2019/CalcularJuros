using CalculoJuros.Core.Models;

namespace CalculoJuros.Core.Utilitarios
{
    public static class Utilitario
    {
        const double JUROS_PADRAO = 0.01;
        const string ENDERECO_GITHUB = "https://github.com/marcosreis2019/CalcularJuros";

        public static TaxaJuros GetTaxaJurosDefault()
        {
            return new TaxaJuros { Juros = JUROS_PADRAO };
        }

        public static GitHub GetEnderecoGitHub()
        {
            return new GitHub { EnderecoGitProjeto = ENDERECO_GITHUB };
        }
    }
}