using System;
using System.Collections.Generic;
using System.Text;
using static week2.Factory.CreditCardMovement;

namespace week2.Factory
{
    public class Factory
    {
        //in base al movement che mi ritorna voglio crearlo
        public static IMovement FatoryMovement(string tipo, double importo, DateTime data)
        {
            IMovement movement = null;

            if (tipo.Equals("Cash"))
            {
                //richiedi nome esecutore
                Console.WriteLine("Inserisci il nome dell'esecutore:");
                string exec = Console.ReadLine();

                movement = new CashMovement(importo, data, exec);
            }
            else if (tipo.Equals("CreditCard"))
            {
                //richiedi il tipo della carta
                Console.WriteLine("Inserisci il tipo di Carta tra i seguenti:");
                Console.WriteLine(" - AMEX");
                Console.WriteLine(" - VISA");
                Console.WriteLine(" - MASTERCARD");
                Console.WriteLine(" - OTHER");
                string tipoCarta = Console.ReadLine();
                while (tipoCarta != "AMEX" && tipoCarta != "VISA" && tipoCarta != "MASTERCARD" && tipoCarta != "OTHER")
                {
                    Console.WriteLine("Scegli uno dei tipi proposti!");
                    tipoCarta = Console.ReadLine();
                }
                Tipi t;
                if (tipoCarta == "AMEX") t = Tipi.AMEX;
                else if (tipoCarta == "VISA") t = Tipi.VISA;
                else if (tipoCarta == "MASTERCARD") t = Tipi.MASTERCARD;
                else t = Tipi.OTHER;

                //richiedi il numero della carta
                Console.WriteLine();
                Console.WriteLine("Inerisci il numero della Carta: ");
                string numero = Console.ReadLine();

                movement = new CreditCardMovement(importo, data, t, numero);
            }
            else if (tipo.Equals("Transfert"))
            {
                //richiedi banca di origine
                Console.WriteLine("Inserisci il nome della Banca d'origeine:");
                string bOrigine = Console.ReadLine();

                //richiedi banca di destinazione
                Console.WriteLine("Inserisci il nome della Banca di destinazione:");
                string bDest = Console.ReadLine();

                movement = new TransfertMovement(importo, data, bOrigine, bDest);
            }
            else
            {
                Console.WriteLine("Operazione non disponibile!");
                return null;
            }

            return movement;
        }
    }
}