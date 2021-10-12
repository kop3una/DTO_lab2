using Ganaraters.PrimitiveTypeGenerator;
using System;

namespace Ganaraters
{
    public class PrimitiveGeneratorFactory
    {
        private static readonly PrimitiveGeneratorFactory instance = new PrimitiveGeneratorFactory();
        private readonly IGenerate IntGenerator = new IntGenerator();
        private readonly IGenerate ByteGenerator = new ByteGenerator();
        private PrimitiveGeneratorFactory()
        {
        }
        public static PrimitiveGeneratorFactory GetInstance()
        {
            return instance;
        }

        public IGenerate GetGenerator(Type type)
        {
            switch (type.Name)
            {
                case "Int32": return IntGenerator;
                case "Byte": return ByteGenerator;
            }
            return null;
        }

    }
}
