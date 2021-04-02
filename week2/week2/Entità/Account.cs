using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using week2.Factory;

namespace week2.Entità
{
    public class Account<T> :IEnumerable<T> where T : IMovement
    {
        //lista
        private List<T> movements = new List<T>();

        //proprietà
        public string NumeroConto { get; set; }
        public string NomeBanca { get; set; }
        public double Saldo { get; set; }
        public DateTime DataUltimaOperazione { get; set; }

        //costruttore
        public Account() { }
        public Account(string conto, string nome, double saldo)
        {
            NumeroConto = conto;
            NomeBanca = nome;
            Saldo = saldo;
            //data ultima operazione null perchè non ne ha ancora fatte
        }

        //metodi

        //operatore +, aggiungere alla lista dei movimenti

        public static Account<T> operator +(Account<T> account, IMovement movement)
        {
            Account<T> somma = new Account<T>
            {
                NumeroConto = account.NumeroConto,
                NomeBanca = account.NomeBanca,
                Saldo = account.Saldo + movement.Importo,
                DataUltimaOperazione = movement.DataMovimento,
                movements = account.movements
            };

            somma.movements.Add((T)movement);

            return somma;
        }

        //operatore -
        public static Account<T> operator -(Account<T> account, IMovement movement)
        {
            Account<T> sottrazione = new Account<T>
            {
                NumeroConto = account.NumeroConto,
                NomeBanca = account.NomeBanca,
                Saldo = account.Saldo - movement.Importo,
                DataUltimaOperazione = movement.DataMovimento,
                movements = account.movements
            };

            sottrazione.movements.Add((T)movement);

            return sottrazione;
        }

        //Statement: stampa i dati del conto con la lista di movimenti
        public void Statement()
        {
            Console.WriteLine($"Numero Conto: {NumeroConto} della Banca {NomeBanca} - Saldo: {Saldo}, Data ultima operazione: {DataUltimaOperazione.ToShortDateString()}");
            Console.WriteLine("Lista dei Movimenti: ");

            foreach (var movimenti in movements)
            {
                Console.WriteLine(movimenti);
            }
        }

        //metodi dell'interfaccia IEnumerator
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var movement in movements)
            {
                yield return movement;
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
