using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class ShortGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(short);

        public object GetValue()
        {
            return (short)random.Next();
        }
    }
}
