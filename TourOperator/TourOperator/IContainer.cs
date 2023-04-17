using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperator
{
    interface IContainer
    {
        bool isEmpty();
        void makeEmpty();
        int size();
    }
}
