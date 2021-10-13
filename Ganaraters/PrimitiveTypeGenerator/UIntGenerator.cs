using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class UIntGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(uint);

        public object GetValue()
        {
            return (uint)random.Next();
        }
    }
}
