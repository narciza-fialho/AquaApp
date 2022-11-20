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
        public string Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int ConsumoTotal { get; set; }
    }
}
