using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class IntGenerator : IGenerate
    {
        private Random random = new Random();
        public object GetValue()
        {
            int numberSign = random.Next(0, 1);
            if (numberSign == 0)
            {
                return random.Next();
            }
            else
            {
                return -random.Next();
            }
        }
    }
}
