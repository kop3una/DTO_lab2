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
            {typeof(bool), new BooleanGenerator()},
            {typeof(int), new IntGenerator()},
            {typeof(byte), new ByteGenerator()},
            {typeof(sbyte), new SByteGenerator() },
            {typeof(short), new ShortGenerator() },
            {typeof(ushort), new USShortGenerator()},
            {typeof(uint), new UIntGenerator()},
            {typeof(long), new LongGenerator()},
            {typeof(ulong), new ULongGenerator()},
            //{typeof(float), new FloatGenerator()},
            {typeof(double), new DoubleGenerator()},
            {typeof(decimal), new DecimialGenerator()},
            {typeof(DateTime), new DateTimeGenerator()}
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
            try
            {
                generators.Add(type, generator);
            } catch (ArgumentException) { 
            }
        }

    }
}
