using System;
using System.Collections.Generic;
using System.Text;

namespace AquaApp.Models
{
    public class DiariaArray
    {
        public List<Diaria> Diarias { get; set; }
        public int Count { get; set; }
    }

    public class Diaria
    {
        public int IdDia { get; set; }
        public decimal Valor { get; set; }
        public DateTime DiaHora { get; set; }
        public bool Situação { get; set; }
    }
}
