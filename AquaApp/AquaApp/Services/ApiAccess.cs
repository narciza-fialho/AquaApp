using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AquaApp.Services
{
    public class ApiAccess
    {
        private readonly string _urlApi;
        private readonly string _userApi;
        private readonly string _passApi;
        private HttpClient client;

        public ApiAccess()
        {
            _urlApi = string.Empty;
            _userApi = string.Empty;
            _passApi = string.Empty;

            client = new HttpClient();

            client.BaseAddress = new Uri(_urlApi);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Usuario", _userApi);
            client.DefaultRequestHeaders.Add("Senha", _passApi);
        }

        /*public bool ConsultarFeriado(DateTime data)
        {
            try
            {
                var consulta = RespostaApi(data.ToString("yyyyMMdd")).Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task RespostaApi(string data)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlFeriado}/feriado/{data}/{data}").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                FeriadoArray retorno = JsonConvert.DeserializeObject<FeriadoArray>(responseContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return retorno.feriados.Any(e => (e.TipoFeriado == "N"));
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }*/

    }
}
