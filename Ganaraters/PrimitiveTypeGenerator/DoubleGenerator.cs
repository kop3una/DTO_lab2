using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class DoubleGenerator : IGenerate
    {
        public Type GeneratedType => typeof(double);

        Random random = new Random();

        public object GetValue()
        {
            return random.NextDouble();
        }
    }
}
