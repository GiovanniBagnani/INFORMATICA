using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator
{
    public class TourOperator : IDictionary, IContainer
    {
        string nextClientCode;
        Dictionary<IComparable, object> dizionario;
        public TourOperator(string initialClientCode)
        {
            this.nextClientCode = initialClientCode;
            this.dizionario = new Dictionary<IComparable, object>();
        }

        public void add(String nome, String dest)
        {
            //inizializzo una variabile di tipo cliente
            Client client = new Client(nome, dest);
            //aggiungo il cliente nel dizionario
            dizionario.Add(nextClientCode, client);
            //successivamente incremento il valore del codice
            NextCode(nextClientCode);
        }
        private void NextCode(string code)
        {
            string numbers = code.Substring(1);//parte numerica del codice ottenuta da dopo il primo carattere 
            char letter = code[0]; //lettera del codice
            int number = Convert.ToInt32(numbers);
            int length = numbers.Length;//variabile utile per avere un codice di 4 cifre
            if (number < 999)
            {
                number++;
                //con il ciclo ottengo la parte numerica sempre di tre cifre anche quando l'incremento restituisce meno di 3 cifre
                for (int i = 0; i < length - number.ToString().Length; i++)
                {
                    numbers += "0";
                }
                numbers += number.ToString();
            }
            else if(++letter <= 'Z')//controllo che la lettera una volta incrementata sia minore o uguale di Z
            {
                letter++;
                number = 0;
                numbers = "000";
            }
            else
            {
                throw new Exception("Codici esauriti!");
            }
            nextClientCode = letter + numbers;
        }
        public override string ToString()
        {
            //restituisce il contenuto del dizionario, un cliente per riga, con il seguente formato: codice cliente : nome: destinazione.
            string clienti = "";
            foreach (KeyValuePair<IComparable, object> cliente in dizionario)
            {
                Client temp = (Client)cliente.Value;
                clienti += $"{cliente.Key} : {temp.Name} : {temp.Dest} \n";
            }
            return clienti;
        }

        //inizio implementazione interfaccia IDictionary
        public void insert(IComparable key, object attribute)
        {
            if(dizionario.ContainsKey(key))//controllo se la chiave esiste
            {
                dizionario[key] = attribute;//la coppia di valori viene sovrascritta
            }
            else
            {
                dizionario.Add(key, attribute);//la coppia di valori viene creata
            }
        }
        public object find(IComparable key)
        {
            if (dizionario.ContainsKey(key))
            {
                return dizionario[key];//restituisce l'attributo associato alla chiave key nel dizionario
            }
            else 
            {
                //se non viene trovato il codice, si genera un'eccezione
                throw new Exception("Codice cliente non presente");
            }
        }
        public object remove(IComparable key)
        {
            object attribute = dizionario[key];//salvo il valore dell'attributo da eliminare
            if (dizionario.Remove(key))//rimuove l'elemento e ritorna true se avviene l'eliminazione, false se non trova la chiave
            {
                return attribute;
            }
            else
            {
                throw new Exception("Codice cliente non presente");
            }
        }
        //fine implementazione interfaccia IDictionary

        //inizio implementazione interfaccia IContainer
        public bool isEmpty()
        {
            if(dizionario.Count == 0)//controllo se il dizionario è vuoto in base al numero di elementi
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void makeEmpty()
        {
            //cancella il contenuto del dizionario
            dizionario.Clear();
        }
        public int size()
        {
            //ritorna il numero di elementi presenti nel dizionario
            return dizionario.Count;
        }
        //fine implementazione interfaccia IContainer

        // classi interne
        private class Client
        {
            String name; // nome del cliente
            String dest; // destinazione del viaggio
            public Client(string name, string dest)
            {
                this.name = name;
                this.dest = dest;
            }
            //proprietà
            public string Name 
            {
                get { return name; }
            }
            public string Dest
            {
                get { return dest; }
            }
        }

        private class Coppia : IComparable
        {
            string code;
            Client client;

            public Coppia(string aCode, Client aClient)
            {
                this.code = aCode;
                this.client = aClient;
            }
            public int CompareTo(object obj)
            {
                Coppia tmpC = (Coppia)obj;
                return code.CompareTo(tmpC.code);
            }
        }
    }
}
