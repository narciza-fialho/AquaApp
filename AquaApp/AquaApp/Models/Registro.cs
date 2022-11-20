using System;
using System.Collections.Generic;
using System.Text;

namespace AquaApp.Models
{
    public class RegistroArray
    {
        public List<Registro> Registros { get; set; }
        public int Count { get; set; }
    }

    public class Registro
    {
        public string Id { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public DateTime? DataSolucao { get; set; }
        public string Mensagem { get; set; }        
        public bool Decisao { get; set; }

    }
}
