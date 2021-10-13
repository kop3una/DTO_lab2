using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class DecimialGenerator : IGenerate
    {
        Random random = new Random();
        public Type GeneratedType => typeof(decimal);

        public object GetValue()
        {

            return (decimal)random.NextDouble()*100000000;
        }
    }
}
