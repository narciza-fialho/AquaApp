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

        public bool RetornaRegistroBool()
        {
            List<Registro> registros = apiAccess.ConsultarRegistroAbertos();

            return (registros.Count > 0);
        }

        public List<string> RetornaMensagemUsuario()
        {
            List<Registro> lista = apiAccess.ConsultarRegistroAbertos();
            List<string> retorno = new List<string>();
            if (lista.Count > 0)
            {
                retorno.Add("Aumento de consumo detectato, deseja fechar a válvula?");
                retorno.Add("#FA8072");
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
        }
    }
}