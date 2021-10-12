using System;
using Ganaraters;

namespace MyFaker
{
    public class Faker : IFaker
    {
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            if (type.IsPrimitive)
            {
                IGenerate generator = PrimitiveGeneratorFactory.GetInstance().GetGenerator(type);
                return generator.GetValue();
            }
            return null;
        }
    }
}
