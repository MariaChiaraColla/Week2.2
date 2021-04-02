using System;
using System.Collections.Generic;
using System.Text;

namespace week2.Factory
{
    public class CashMovement : IMovement
    {
        //proprietà
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string Esecutore { get; set; }

        //costruttore
        public CashMovement(double importo, DateTime data, string exec)
        {
            Importo = importo;
            DataMovimento = data;
            Esecutore = exec;
        }

        //metodi
        public override string ToString()
        {
            return $"{DataMovimento.ToShortDateString()}) {Importo} Euro - Esecutore: {Esecutore}";
        }
    }
}
