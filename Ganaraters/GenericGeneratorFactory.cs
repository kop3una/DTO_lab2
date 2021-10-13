using Ganaraters.GenericTypeGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters
{
    public class GenericGeneratorFactory
    {
        private static readonly GenericGeneratorFactory instance = new GenericGeneratorFactory();
        private Dictionary<Type, IGenerateGeneric> generators = new Dictionary<Type, IGenerateGeneric>
        {
            {typeof(List<>), new ListGenerator()},
            {typeof(Array),new ArrayGenerator()}
        };

        private GenericGeneratorFactory()
        {
        }
        public static GenericGeneratorFactory GetInstance()
        {
            return instance;
        }

        public IGenerateGeneric GetGenerator(Type type)
        {
            try
            {
                Type tList = typeof(List<>);
                if (type.Name.Equals(tList.Name))
                {
                    return generators[tList];
                }
                else if (type.BaseType.Equals(typeof(Array))){
                    return generators[typeof(Array)];

                } else  
                {
                    return null;
                }
                
            }
            catch (KeyNotFoundException e)
            {
                return null;
            }

        }

    }
}
