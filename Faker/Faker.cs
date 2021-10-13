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
        public Stack<Type> generatedTypes = new Stack<Type>();

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
            } catch (InvalidCastException) {
                try
                {
                    return (T)Activator.CreateInstance(typeof(T));

                }
                catch (MissingMethodException)
                {
                    return default(T);
                }
               
            } catch (NullReferenceException)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
        }

        private object Create(Type type)
        {

            if (type.IsClass && !type.IsPrimitive && !type.IsPointer && !type.Equals(typeof(string)) && !type.Equals(typeof(DateTime)) &&
                !type.IsGenericType && !type.IsArray && !generatedTypes.Contains(type))
            {
                int maxConstructorFieldsCount = 0, curConstructorFieldsCount;
                ConstructorInfo constructorToUse = null;

                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    curConstructorFieldsCount = constructor.GetParameters().Length;
                    if (curConstructorFieldsCount > maxConstructorFieldsCount)
                    {
                        maxConstructorFieldsCount = curConstructorFieldsCount;
                        constructorToUse = constructor;
                    }
                }

                generatedTypes.Push(type);
                if (constructorToUse == null)
                {
                    return CreateByProperties(type);
                }
                else
                {
                    return CreateByConstructor(type, constructorToUse);
                }
               // generatedTypes.Pop();
            //else if (type.IsValueType)
            //{
            //    generated = Activator.CreateInstance(type);
            //}
            //else
            //{
            //    generated = null;
            //}
        
           // return generated;
        } else
            {
                if (type.IsPrimitive || type.Equals(typeof(string)) || type.Equals(typeof(DateTime)))
                {
                    IGenerate generator = PrimitiveGeneratorFactory.GetInstance().GetGenerator(type);
                    if (generator != null)
                    {
                        return generator.GetValue();
                    }
                    else
                    {
                        return null;
                    }

                }
                else if (type.IsGenericType || type.IsArray)
                {
                    IGenerateGeneric generator = GenericGeneratorFactory.GetInstance().GetGenerator(type);
                    if (generator != null)
                    {
                        if (!type.IsArray)
                        {
                            return generator.GetValue(type.GenericTypeArguments[0]);
                        }
                        else
                        {
                            return generator.GetValue(type.GetElementType());
                        }

                    }
                    else
                    {
                        return null;
                    }
                }
            }
            
            return null;
        }

        //protected bool TryCreateByCustomGenerator(ParameterInfo parameterInfo, Type type, out object generated)
        //{
        //    foreach (KeyValuePair<PropertyInfo, IBaseTypeGenerator> keyValue in customGenerators)
        //    {
        //        if ((keyValue.Key.Name.ToLower() == parameterInfo.Name.ToLower()) && keyValue.Value.GeneratedType.Equals(parameterInfo.ParameterType)
        //            && keyValue.Key.ReflectedType.Equals(type))
        //        {
        //            generated = keyValue.Value.Generate();
        //            return true;
        //        }
        //    }
        //    generated = default(object);
        //    return false;
        //}

        protected object CreateByProperties(Type type)
        {
            try
            {
                object generated = Activator.CreateInstance(type);

                foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                {
                    fieldInfo.SetValue(generated, this.Create(fieldInfo.FieldType));
                }

                foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
                {
                    if (propertyInfo.CanWrite)
                    {
                        try
                        {
                            propertyInfo.SetValue(generated, this.Create(propertyInfo.PropertyType));
                        } catch
                        {
                            return null;
                        }
                        
                    }
                }
                return generated;
            } catch (MissingMethodException)
            {
                return null;
            }
            
        }

        protected object CreateByConstructor(Type type, ConstructorInfo constructor)
        {
            var parametersValues = new List<object>();

            foreach (ParameterInfo parameterInfo in constructor.GetParameters())
            {
                parametersValues.Add(this.Create(parameterInfo.ParameterType));
            }

            try
            {
                return constructor.Invoke(parametersValues.ToArray());
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }
    }
}
