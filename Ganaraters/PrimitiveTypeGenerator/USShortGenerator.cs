using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class USShortGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(ushort);

        public object GetValue()
        {
            return (ushort)random.Next();
        }
    }
}
