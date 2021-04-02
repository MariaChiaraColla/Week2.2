using System;
using week2.Entità;
using week2.Factory;

namespace week2
{
    class Program
    {
        //per gestire i Movement ho utilizzato una factory, così in base all'operazione che vuole eseguire l'utente
        // creo l'istanza della classe corrispondente

        //per gestire l'Account ho creato una classe generica che accetta solo tipi dell'interfaccia che ho utilizzato
        // per creare la factory, al suo interna uso una lista di IMovement (che possono essere dei vari tipi contenuti
        // nella factory)

        static void Main(string[] args)
        {
            Console.WriteLine("--Benvenuto in Now Banking!--");

            //registro l'account
            Console.WriteLine();
            Console.WriteLine("Registrati!");
            //numero conto
            Console.WriteLine("Inserisci il numero del tuo conto:");
            string conto = Console.ReadLine();
            //nome della banca
            Console.WriteLine("Inserisci il nome della tua banca:");
            string nomeB = Console.ReadLine();
            //saldo iniziale + controlli
            Console.WriteLine("Inserisci il Saldo iniziale:");
            double saldo = 0.0;
            bool ok = Double.TryParse(Console.ReadLine(),out saldo);
            while(ok == false)
            {
                Console.WriteLine("Inserisci un Saldo Valido!");
                ok = Double.TryParse(Console.ReadLine(), out saldo);
            }

            //creo la nuova istanza
            Account<IMovement> account = new Account<IMovement>(conto, nomeB, saldo);

            char key = 'z';

            //mostro le operazioni (Movement) che può eseguire
            while(key != 'q')
            {
                Console.WriteLine();
                Console.WriteLine("Scegli che operazione eseguire tra le seguenti:");
                Console.WriteLine("  a) Movimeto in Contanti,");
                Console.WriteLine("  b) Movimento con Carta di Credito,");
                Console.WriteLine("  c) Movimento con Bonifico(trasferimento),");
                Console.WriteLine("  q) Per uscire dal programma");
                //controllo dell'input
                string op = Console.ReadLine();
                while(op != "a" && op != "b" && op != "c" && op != "q")
                {
                    Console.WriteLine("inserisci una lettere valida!");
                    op = Console.ReadLine();
                }
                //se è q esco
                if (op == "q") Environment.Exit(0);

                key = Convert.ToChar(op);

                //chiedo l'importo dell'operazione
                Console.WriteLine("Inserisci l'importo dell'operazione: ");
                //faccio il controllo sull'input
                double importo = 0.0;
                bool ok1 = Double.TryParse(Console.ReadLine(), out importo);
                while (ok1 == false)
                {
                    Console.WriteLine("Inserisci un Saldo Valido!");
                    ok1 = Double.TryParse(Console.ReadLine(), out importo);
                }

                IMovement mov = null;

                switch (key)
                {
                    case 'a':
                        mov = Factory.Factory.FatoryMovement("Cash",importo, DateTime.Now);
                        break;
                    case 'b':
                        mov = Factory.Factory.FatoryMovement("CreditCard", importo, DateTime.Now);
                        break;
                    case 'c':
                        mov = Factory.Factory.FatoryMovement("Transfert", importo, DateTime.Now);
                        break;
                }
                //non faccio il controllo su mov per vedere se è nullo perchè non posso passargli un valore
                //diverso da quelli che può avere.
                Console.WriteLine();
                Console.WriteLine("Movimenti disponibili:");
                Console.WriteLine("  a) Prelievo");
                Console.WriteLine("  b) Deposito");
                Console.WriteLine("  q) Per Uscire");
                //controlli sull'input
                string op1 = Console.ReadLine();

                while (op1 != "a" && op1 != "b" && op1 != "q")
                {
                    Console.WriteLine("inserisci una lettere valida!");
                    op1 = Console.ReadLine();
                }
                //se è q esci
                if (op1 == "q") Environment.Exit(0);

                key = Convert.ToChar(op1);

                switch (key)
                {
                    //prelievo
                    case 'a':
                        account = account - mov;
                        break;
                    //deposito
                    case 'b':
                        account = account + mov;
                        break;

                }
                Console.Clear();

                //stampo l'account con i suoi dati aggiornati e tutti i suoi movimenti
                account.Statement();
                
                Console.WriteLine();
            }

        }
    }
}
