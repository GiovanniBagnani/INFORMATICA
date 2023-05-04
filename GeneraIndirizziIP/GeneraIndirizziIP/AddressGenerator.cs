using System;

namespace GeneraIndirizziIP
{
    interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }

    public class AddressGenerator : IAddress
    {
        string _address;
        byte[] _addressBytes;
        byte[] _subnetMask;

        public AddressGenerator(string address)
        {
            if (address.Length != 35)//considero i punti 3 ounti di separazione 11000000.00000000.00000000.00000000
            {
                throw new ArgumentException("Bit count must be 32, separated by a dot!");
            }
            else
            {
                _address = address;
            }
        }
        public string generateIPv4()
        {
            _addressBytes = ConvertToByte(_address);
            return _addressBytes[0] + "." + _addressBytes[1] + "." + _addressBytes[2] + "." + _addressBytes[3];
        }
        public string generateSubnet()
        {
            int cidr;
            Random estrai = new Random();
            cidr = estrai.Next(0, 32);
            string subnet = SubnetBinaria(cidr);
            _subnetMask = ConvertToByte(subnet);
            return _subnetMask[0] + "." + _subnetMask[1] + "." + _subnetMask[2] + "." + _subnetMask[3];
        }
        public string SubnetBinaria(int cidr)
        {
            string subnetBin = "";
            for (int i = 0; i < cidr; i++)
            {
                if ((i == 8 || i == 16 || i == 24) && i != 0)
                {
                    subnetBin += ".";
                }
                subnetBin += "1";
            }
            int j;
            if (cidr <= 8)
                j = subnetBin.Length - 1;
            else if(cidr <= 16)
                j = subnetBin.Length;
            else if(cidr <= 24)
                j = subnetBin.Length + 1;
            else
                j = subnetBin.Length + 2;

            for (int i = cidr; i < 35; i++)//35 ok considero i punti 
            {
                if ((i == 8 || i == 16 || i == 24) && i != 0)
                    subnetBin += ".";
                subnetBin += "0";
            }
            return subnetBin;
        }
        public byte[] ConvertToByte(string address)
        {
            byte[] Bytes = new byte[4];
            int intero;
            string bit;
            int convertito;
            string[] byteSingolo = address.Split('.');
            for (int i = 0; i < 4; i++)
            {
                intero = 0;
                bit = byteSingolo[i];
                for (int j = 0; j < 8; j++)
                {
                    convertito = int.Parse(bit[j].ToString());
                    intero += convertito * (int)Math.Pow(2, 7 - j);
                }
                Bytes[i] = Convert.ToByte(intero);
            }
            return Bytes;
        }
    }
}
