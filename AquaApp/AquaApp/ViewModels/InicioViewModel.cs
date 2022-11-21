using AquaApp.Models;
using AquaApp.Services;
using AquaApp.Views;
using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace AquaApp.ViewModels
{
    public class InicioViewModel : BaseViewModel
    {
        public ApiAccess apiAccess { get; set; }
        public string consumoAtual { get; set; }
        public string consumoPassado { get; set; }
        public string MensagemUsuario { get; set; }
        public string FundoMensagem { get; set; }

        public static readonly SKColor TextColor = SKColors.Black;        

        public InicioViewModel() 
        {
            apiAccess = new ApiAccess();

            Title = "Aqua App";

            var temp = RetornaConsumoPassado();
            consumoPassado = temp;
            temp = RetornaConsumoAtual();
            consumoAtual = temp;
            List<string> tempo = RetornaMensagemUsuario();
            MensagemUsuario = tempo[0];
            FundoMensagem = tempo[1];
        }

        public Chart GraficoConsumo()
        {
            DateTime dateTime = DateTime.Now;
            List<Mensal> mensalArray = apiAccess.ConsultarMensal(dateTime.Year);
            List<ChartEntry> entries = new List<ChartEntry>();

            if (mensalArray.Count > 0 ) 
            {
                foreach(var item in mensalArray)
                {
                    entries.Add(
                        new ChartEntry((float)item.ConsumoTotal)
                        {
                            Label = item.Mes.ToString(),
                            ValueLabel = item.ConsumoTotal.ToString(),
                            Color = SKColor.Parse("#F0F8FF"),
                            TextColor = TextColor
                        });
                }
            }

            return 
                new LineChart()
                {
                    Entries = entries,
                    LineMode = LineMode.Straight,
                    LineSize = 8,
                    PointMode = PointMode.Circle,
                    PointSize = 18,
                    LabelTextSize = 40,
                    LabelOrientation = Orientation.Horizontal,
                    ValueLabelOrientation= Orientation.Horizontal,
                    BackgroundColor = SKColor.Parse("#B0C4DE")
                };

        }

        public string RetornaConsumoAtual()
        {
            DateTime dateTime = DateTime.Now;
            List<Diaria> lista = apiAccess.ConsultarDiaria(dateTime.Month);

            if (lista.Count > 0)
            {
                var retorno = lista.Where(m => m.DiaHora.Month == dateTime.Month).ToList();
                decimal converte = 0;
                foreach(var item in retorno)
                {
                    converte += item.Valor;
                }

                return (converte / 1000).ToString();
            } else
                return "0";
        }

        public string RetornaConsumoPassado()
        {
            DateTime dateTime = DateTime.Now;
            List<Mensal> lista = apiAccess.ConsultarMensal(dateTime.Year);

            if (lista.Count > 0)
            {
                var retorno = lista.Where(m => m.Mes == (dateTime.Month - 1)).FirstOrDefault();
                return retorno.ConsumoTotal.ToString();
            } else
                return "0";
        }

        public List<string> RetornaMensagemUsuario()
        {
            List<Registro> lista = apiAccess.ConsultarRegistroAbertos();
            List<string> retorno = new List<string>();
            if (lista.Count > 0)
            {
                retorno.Add("Aumento de consumo detectato, verifique em veja mais");
                retorno.Add("#FA8072");
                return retorno;
            } else
            {
                retorno.Add("Tudo certo desde a última leitura");
                retorno.Add("#98FB98");
                return retorno;
            }
        }
    }
}
