using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.GenericTypeGenerator
{
    public class ArrayGenerator : IGenerateGeneric
    {
        public Type GeneratedType => typeof(Array);

        public object GetValue(Type type)
        {
            Array result = Array.CreateInstance(type, (byte)PrimitiveGeneratorFactory.GetInstance().GetGenerator(typeof(byte)).GetValue());
            IGenerate generator = PrimitiveGeneratorFactory.GetInstance().GetGenerator(type);
            if (generator != null){
                for (int i = 0; i < result.Length; i++)
                {
                    result.SetValue(generator.GetValue(), i);
                }
            }
            return result;
        }
    }
}
