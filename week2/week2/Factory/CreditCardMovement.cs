using System;
using System.Collections.Generic;
using System.Text;

namespace week2.Factory
{
    public class CreditCardMovement : IMovement
    {
        //enum
        public enum Tipi
        {
            AMEX,
            VISA,
            MASTERCARD,
            OTHER
        }

        //proprietà
        public double Importo { get; set; }
        public DateTime DataMovimento { get; set; }
        public Tipi Tipo { get; set; }
        public string NumeroCarta { get; set; }

        //costruttore
        public CreditCardMovement(double importo, DateTime data, Tipi tipo, string carta)
        {
            Importo = importo;
            DataMovimento = data;
            Tipo = tipo;
            NumeroCarta = carta;
        }

        //metodi
        public override string ToString()
        {
            return $"{DataMovimento.ToShortDateString()}) {Importo} Euro - Tipo di carta: {Tipo} con numero: {NumeroCarta}";
        }
    }
}
