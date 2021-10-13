using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class BooleanGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(bool);

        public object GetValue()
        {
            int r = random.Next(0, 2);
            if (r == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
