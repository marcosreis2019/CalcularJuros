using System;
using System.Net.Http;
using CalculoJuros.Core.Models;
using Newtonsoft.Json;

namespace CalculoJuros.Core.Services
{
    public static class UtilHttpClient
    {
        const string DOMINIO = "http://localhost:51211";
        const string PATH_RELATIVO = "/v1/TaxaJuros";

        public static Tuple<double, string> GetTaxaJuros()
        {
            double taxaJuros = 0;
            string mensagemErro = string.Empty;

            using (HttpClient objHttpClient = new HttpClient())
            {
                try
                {
                    objHttpClient.BaseAddress = new Uri(DOMINIO);
                    objHttpClient.DefaultRequestHeaders.Accept.Clear();

                    HttpResponseMessage objHttpResponseMessage = objHttpClient.GetAsync(PATH_RELATIVO).Result;

                    if (objHttpResponseMessage.IsSuccessStatusCode)
                    {
                        string result = objHttpResponseMessage.Content.ReadAsStringAsync().Result;

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            TaxaJuros objTaxaJuros = JsonConvert.DeserializeObject<TaxaJuros>(result);

                            if (objTaxaJuros != null)
                            {
                                taxaJuros = objTaxaJuros.Juros;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    mensagemErro = string.Format("{0}-_-{1}", ex.Message, ex.StackTrace);
                }
            }

            return new Tuple<double, string>(taxaJuros, mensagemErro);
        }
    }
}