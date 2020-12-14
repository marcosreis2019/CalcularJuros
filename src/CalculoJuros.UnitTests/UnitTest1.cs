using CalculoJuros.Core.Models;
using CalculoJuros.Core.Utilitarios;
using NUnit.Framework;
using System;

namespace CalculoJuros.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetTaxaJuros()
        {
            // Pega o juros que retornou da API.
            TaxaJuros objTaxaJuros = Utilitario.GetTaxaJurosDefault();

            double juros = 0;

            if (objTaxaJuros != null)
            {
                juros = objTaxaJuros.Juros;
            }

            Assert.IsTrue(juros > 0);
        }

        [Test]
        public void TestCalculaJuros()
        {
            double valorInicial = 100;
            int meses = 5;

            // Pega o juros que retornou da API.
            TaxaJuros objTaxaJuros = Utilitario.GetTaxaJurosDefault();

            double juros = 0;
            double valorFinalTruncado = 0;

            if (objTaxaJuros != null)
            {
                juros = objTaxaJuros.Juros;
            }

            if (juros > 0)
            {
                // Calcula o valor final do juros composto.
                double valorFinal = valorInicial * Math.Pow(1 + juros, meses);

                // Trunca o valor final em duas casas decimais.
                valorFinalTruncado = Math.Truncate(100 * valorFinal) / 100;
            }

            Assert.IsTrue(valorFinalTruncado == 105.10);
        }

        [Test]
        public void TestEnderecoGitHub()
        {
            string urlGithub = string.Empty;

            GitHub objGitHub = Utilitario.GetEnderecoGitHub();

            if (objGitHub != null)
            {
                urlGithub = objGitHub.EnderecoGitProjeto;
            }

            Assert.IsTrue(!string.IsNullOrWhiteSpace(urlGithub));
        }
    }
}