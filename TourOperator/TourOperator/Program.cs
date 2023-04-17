using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "", dest = "", code = "";
            int nClients = 0;
            Console.WriteLine("Inserire il numero di clienti:");
            nClients = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserire il codice cliente:");
            code = Console.ReadLine();
            TourOperator t = new TourOperator(code);
            
            for(int i = 0; i < nClients; i++)//itera fino al raggiungimento del numero di clienti scelto
            {
                //legge i dati nome e destinazione
                Console.WriteLine("Inserire il nome del cliente:");
                name = Console.ReadLine();
                Console.WriteLine("Inserire la destinazione del cliente:");
                dest = Console.ReadLine();
                t.add(name, dest);//inserisce i clienti nel dizionario
            }
            Console.WriteLine(t.ToString());//stampa il contenuto del dizionario
            Console.ReadLine();
        }
    }
}
