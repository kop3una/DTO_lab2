using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Ganaraters;

namespace MyFaker
{
    public class Faker : IFaker
    {
        private string path = "C:\\Users\\kiril\\OneDrive\\Рабочий стол\\Учеба\\3 курс\\СПП\\lab2\\pluginsInLab";

        public Faker()
        {
            List<Assembly> assemblies = new List<Assembly>();
            try
            {
                foreach (string file in Directory.GetFiles(this.path, "*.dll"))
                {
                    try
                    {
                        assemblies.Add(Assembly.LoadFile(file));
                    }
                    catch (BadImageFormatException)
                    { }
                    catch (FileLoadException)
                    { }
                }
            }
            catch (DirectoryNotFoundException)
            { }

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (Type typeInterface in type.GetInterfaces())
                    {
                        if (typeInterface.Equals(typeof(IGenerate)))
                        {
                            IGenerate generator = (IGenerate)Activator.CreateInstance(type);
                            PrimitiveGeneratorFactory.GetInstance().Add(generator.GeneratedType, generator);
                        }
                    }
                }
            }
        }

        public T Create<T>()
        {
            try
            {
                return (T)Create(typeof(T));
            } catch(InvalidCastException) {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        private object Create(Type type)
        {
            if (type.IsPrimitive || type.Equals(typeof(string)) )
            {
                IGenerate generator = PrimitiveGeneratorFactory.GetInstance().GetGenerator(type);
                if (generator != null)
                {
                    return generator.GetValue();
                }
                else
                {
                    return new object();
                }
                
            }
            return new object();
        }
    }
}
