using System;
using Ganaraters;

namespace Plugins
{
    public class StringGenerator : IGenerate
    {
        string str;
        Random random = new Random();
        public Type GeneratedType => typeof(string);
        public object GetValue()
        {
            for (int i=0; i < 20; i++)
            {
                str += (char)random.Next(65,90);
            }
            return str;
        }
    }
}
