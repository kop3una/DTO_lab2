using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class FloatGenerator : IGenerate
    {
        Random random = new Random();
        public Type GeneratedType => typeof(float);

        public object GetValue()
        {

            return (float)random.NextDouble()*1000000;
        }
    }
}
