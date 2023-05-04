using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneraIndirizziIP
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddressGenerator ad = new AddressGenerator(Console.ReadLine());
            AddressGenerator ad = new AddressGenerator("11000000.10101000.00010000.00000000");
            Console.WriteLine("Inirizzo IP:");
            Console.WriteLine(ad.generateIPv4());
            Console.WriteLine("Subnet mask:");
            Console.WriteLine(ad.generateSubnet());
            Console.ReadLine();

            try
            {
                AddressGenerator test = new AddressGenerator("abc");
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            try
            {
                AddressGenerator Test = new AddressGenerator("-145");
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }

            Console.ReadLine();
        }
    }
}
