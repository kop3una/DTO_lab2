using System;
using System.Collections;
using System.Collections.Generic;


namespace Ganaraters.GenericTypeGenerator
{
    class ListGenerator : IGenerateGeneric
    {
        public Type GeneratedType => typeof(List<>);

        public object GetValue(Type type)
        {
            IList result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
            if (type.IsPrimitive)
            {
                IGenerate generator = PrimitiveGeneratorFactory.GetInstance().GetGenerator(type);
                byte listSize = (byte)PrimitiveGeneratorFactory.GetInstance().GetGenerator(typeof(byte)).GetValue();

                for (int i = 0; i < listSize; i++)
                {
                    result.Add(generator.GetValue());
                }
            }
            else
            {
                IGenerateGeneric generatorGeneric = GenericGeneratorFactory.GetInstance().GetGenerator(type);
                byte listSize = (byte)PrimitiveGeneratorFactory.GetInstance().GetGenerator(typeof(byte)).GetValue();
                Type t = type.GenericTypeArguments[0];

                for (int i = 0; i < listSize; i++)
                {
                    result.Add(generatorGeneric.GetValue(type.GenericTypeArguments[0]));
                }

            }
            
              return result;
            }
        }
    
}
