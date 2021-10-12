using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class ByteGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(byte);

        public object GetValue()
        {
            int numberSign = random.Next(0, 1);
            if (numberSign == 0)
            {
                return (byte)random.Next();
            }
            else
            {
                return (byte)-random.Next();
            }
        }
    }
}
