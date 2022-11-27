using AquaApp.Models;
using AquaApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace AquaApp.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public ApiAccess apiAccess { get; set; }
        public string MensagemUsuario { get; set; }
        public string FundoMensagem { get; set; }

        public RegistroViewModel()
        {
            apiAccess = new ApiAccess();
            Title = "Registro de ocorrências";
            List<string> tempo = RetornaMensagemUsuario();
            MensagemUsuario = tempo[0];
            FundoMensagem = tempo[1];
        }

        public List<Registro> RetornaRegistros()
        {
            List<Registro> registros = apiAccess.ConsultarRegistro();

            return registros.Where(e => e.DataSolucao.HasValue).ToList();
        }

        public string RetornaRegistroBool()
        {
            List<Registro> registrosAbertos = apiAccess.ConsultarRegistroAbertos();
            List<Registro> registros = apiAccess.ConsultarRegistro();
            if (registrosAbertos.Count > 0)
            {
                return "true";
            } else if (registros.LastOrDefault().Decisao)
            {
                return "ultimo";
            }

            return "false";
        }

        public List<string> RetornaMensagemUsuario()
        {
            List<Registro> lista = apiAccess.ConsultarRegistroAbertos();
            List<Registro> registros = apiAccess.ConsultarRegistro();
            List<string> retorno = new List<string>();
            if (lista.Count > 0)
            {
                retorno.Add("Aumento de consumo detectato, deseja fechar a válvula?");
                retorno.Add("#FA8072");
                return retorno;
            }
            else if(registros.LastOrDefault().Decisao)
            {
                retorno.Add("A válvula esta fechada, deseja abrir?");
                retorno.Add("#98FB98");
                return retorno;
            }
            else
            {
                retorno.Add("Tudo certo desde a última leitura, verifique os últimos incidentes abaixo");
                retorno.Add("#98FB98");
                return retorno;
            }
        }

        public void RespondeRegistroFecha()
        {
            List<Registro> lista = apiAccess.ConsultarRegistroAbertos();
            
            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    item.Decisao = true;
                    item.DataSolucao = DateTime.Now;
                    item.Mensagem = "Aumento identificado, usuário escolheu fechar a válvula";
                    apiAccess.AtualizarRegistroAberto(item);
                }
            }
        }

        public void RespondeRegistroNaoFecha()
        {
            List<Registro> lista = apiAccess.ConsultarRegistroAbertos();
            List<Registro> registros = apiAccess.ConsultarRegistro();
            if (lista.Count > 0)
            {
                foreach (var item in lista)
                {
                    item.Decisao = false;
                    item.DataSolucao = DateTime.Now;
                    item.Mensagem = "Aumento identificado, usuário escolheu não fechar a válvula";
                    apiAccess.AtualizarRegistroAberto(item);
                }
            }
            else if (registros.LastOrDefault().Decisao)
            {
                CriaRegistroFecha();
            }
        }

        public void CriaRegistroFecha()
        {
            Registro registro = new Registro();
            registro.DataOcorrencia = DateTime.Now;
            registro.DataSolucao = DateTime.Now;
            registro.Mensagem = "Usuário abriu a válvula";
            registro.Decisao = false;

            if (apiAccess.AbreValvula(registro))
            {

                Console.WriteLine("deu bom");
            }

        }
    }
}