using System;
using System.Collections.Generic;
using System.Text;

namespace week2.Factory
{
    public class TransfertMovement : IMovement
    {
        //proprietà
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public string BancaOrigine { get; set; }
        public string BancaDestinazione { get; set; }

        //costruttore
        public TransfertMovement(double importo, DateTime data, string bOrigine, string bDestinazione)
        {
            Importo = importo;
            DataMovimento = data;
            BancaOrigine = bOrigine;
            BancaDestinazione = bDestinazione;
        }

        //metodi
        public override string ToString()
        {
            return $"{DataMovimento.ToShortDateString()}) {Importo} Euro - Banca d'origine: {BancaOrigine}, Banca di destinazione: {BancaDestinazione}";
        }
    }
}
