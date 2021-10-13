using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class LongGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(long);

        public object GetValue()
        {
            int numberSign = random.Next(0, 1);
            if (numberSign == 0)
            {
                return (long)random.Next();
            }
            else
            {
                return (long)-random.Next();
            }
        }
    }
}
