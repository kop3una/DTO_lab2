using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class SByteGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(sbyte);

        public object GetValue()
        {
            return (sbyte)random.Next();
        }
    }
}
