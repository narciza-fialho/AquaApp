using AquaApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
            _urlApi = "https://dotnet-deploy-test.herokuapp.com/./api";
            _userApi = string.Empty;
            _passApi = string.Empty;

            client = new HttpClient();

            client.BaseAddress = new Uri(_urlApi);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Usuario", _userApi);
            //client.DefaultRequestHeaders.Add("Senha", _passApi);
        }

        public List<Mensal> ConsultarMensal(int ano)
        {
            try
            {
                var consulta = GetMensais(ano).Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Diaria> ConsultarDiaria(int mes)
        {
            try
            {
                var consulta = GetDiaria(mes).Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Registro> ConsultarRegistro()
        {
            try
            {
                var consulta = GetRegistros().Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Registro> ConsultarRegistroAbertos()
        {
            try
            {
                var consulta = GetRegistrosAbertos().Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AtualizarRegistroAberto(Registro registro)
        {
            try
            {
                var consulta = PutRegistro(registro).Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool IncluirRegistroAberto(Registro registro)
        {
            try
            {
                var consulta = PostRegistro(registro).Result;
                return consulta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AbreValvula(Registro registro)
        {
            try
            {
                var consulta = PostRegistroUsuario(registro).Result;
                var retorno = GetAbreValvula().Result;
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Diaria>> GetDiaria(int mes)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlApi}/Diaria").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                List<Diaria> retorno = JsonConvert.DeserializeObject<List<Diaria>>(responseContent);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Mensal>> GetMensais(int ano)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlApi}/Mensal/ano/{ano}").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                List<Mensal> retorno = JsonConvert.DeserializeObject<List<Mensal>>(responseContent);
                           
                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Registro>> GetRegistros()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlApi}/Registro").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                List<Registro> retorno = JsonConvert.DeserializeObject<List<Registro>>(responseContent);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Registro>> GetRegistrosAbertos()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlApi}/Registro/emAberto").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                List<Registro> retorno = JsonConvert.DeserializeObject<List<Registro>>(responseContent);

                return retorno;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PutRegistro(Registro registro)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(registro), Encoding.UTF8, "application/json");
                responseMessage = client.PutAsync($"{_urlApi}/Registro/{registro.Id}", stringContent).Result;
                
                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PostRegistro(Registro registro)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            
            RegistroPost registroPost = new RegistroPost();
            registroPost.DataOcorrencia = registro.DataOcorrencia;
            
            registroPost.Decisao = registro.Decisao;
            registroPost.DataSolucao = null;
            registroPost.Mensagem = "";

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(registroPost), Encoding.UTF8, "application/json");
                responseMessage = client.PostAsync($"{_urlApi}/Registro", stringContent).Result;

                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> PostRegistroUsuario(Registro registro)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            RegistroPost registroPost = new RegistroPost();
            registroPost.DataOcorrencia = registro.DataOcorrencia;
            registroPost.DataSolucao = registro.DataSolucao;
            registroPost.Mensagem = registro.Mensagem;
            registroPost.Decisao = registro.Decisao;

            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(registroPost), Encoding.UTF8, "application/json");
                responseMessage = client.PostAsync($"{_urlApi}/Registro", stringContent).Result;

                responseMessage.EnsureSuccessStatusCode();
                var responseContent = await responseMessage.Content.ReadAsStringAsync();

                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> GetAbreValvula()
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();

            try
            {
                responseMessage = client.GetAsync($"{_urlApi}/Valvula/abrir").Result;
                var responseContent = await responseMessage.Content.ReadAsStringAsync();
                responseMessage.EnsureSuccessStatusCode();

                return responseMessage.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }

    public class RegistroPost
    {
        public DateTime DataOcorrencia { get; set; }
        public DateTime? DataSolucao { get; set; }
        public string Mensagem { get; set; }
        public bool Decisao { get; set; }
    }
}
