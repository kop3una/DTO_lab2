using System;
namespace Ganaraters.PrimitiveTypeGenerator
{
    class IntGenerator : IGenerate
    {
        private Random random = new Random();

        public Type GeneratedType => typeof(int);

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
