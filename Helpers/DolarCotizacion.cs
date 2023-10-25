using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using TrabajoFinalSofttek.Entities;

namespace TrabajoFinalSofttek.Helpers
{

    public class DolarCotizacion
    {
        private readonly HttpClient _httpClient;
        public DolarCotizacion(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<decimal> ValorDolar()
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3Mjk0OTI4NDQsInR5cGUiOiJleHRlcm5hbCIsInVzZXIiOiJmcmFuY28uc2NhZ2xpb25lMkBnbWFpbC5jb20ifQ.mioY_W5aRpB4xlVtJfRlkaeYWXEGK_JOQ-J87JWaO6xKS1j3CyraspOy482E5qY12Rvao4dmbyvNtBb20WG29Q");

            HttpResponseMessage response = await _httpClient.GetAsync("https://api.estadisticasbcra.com/usd_of");

            if (response.IsSuccessStatusCode)
            {
                string contenido = await response.Content.ReadAsStringAsync();
                List<Dolar> cotizacion = JsonConvert.DeserializeObject<List<Dolar>>(contenido);
                if (cotizacion.Count > 0)
                {
                    decimal ultimoValor = cotizacion[cotizacion.Count - 1].v;
                    return ultimoValor;
                }
                else
                {
                    throw new InvalidOperationException("La lista está vacía");
                }
            }
            else
            {
                return 0;
            }
        }





        //public decimal ValorDolar1(string json)
        //{
        //    List<Dolar> response = JsonConvert.DeserializeObject<List<Dolar>>(json);

        //    if (response.Count > 0)
        //    {
        //        decimal ultimoValor = response[response.Count - 1].v;
        //        return ultimoValor;
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("La lista está vacía");
        //    }
        //}
    }
}
