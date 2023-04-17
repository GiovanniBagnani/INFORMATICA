using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator
{
    interface IDictionary //La I viene posta per convenzione sui nomi delle interfacce
    {
        void insert(IComparable key, object attribute);
        object find(IComparable key);
        object remove(IComparable key);
    }
}
