using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFaker
{
    interface IFaker
    {
        T Create<T>();
    }
}
