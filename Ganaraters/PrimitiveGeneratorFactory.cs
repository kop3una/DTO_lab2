using Ganaraters.PrimitiveTypeGenerator;
using System;
using System.Collections.Generic;

namespace Ganaraters
{
    public class PrimitiveGeneratorFactory
    {
        private static readonly PrimitiveGeneratorFactory instance = new PrimitiveGeneratorFactory();
        private Dictionary<Type, IGenerate> generators = new Dictionary<Type, IGenerate>
        {
            {typeof(int), new IntGenerator()},
            {typeof(byte), new ByteGenerator()},
        };

        private PrimitiveGeneratorFactory()
        {
        }
        public static PrimitiveGeneratorFactory GetInstance()
        {
            return instance;
        }

        public IGenerate GetGenerator(Type type)
        {
            try
            {
                return generators[type];
            } catch (KeyNotFoundException e){
                return null;
            }
            
        }

        public void Add(Type type, IGenerate generator)
        {
            generators.Add(type, generator);
        }

    }
}
