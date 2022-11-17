using System;
using System.Collections.Generic;
using System.Text;

namespace AquaApp.Models
{
    public class MensalArray
    {
        public List<Mensal> Mensals { get; set; }
        public int Count { get; set; }
    }

    public class Mensal
    {
        public int IdMes { get; set; }
        public string Mes { get; set; }
        public decimal ConsumoTotal { get; set; }
    }
}
