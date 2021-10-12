using Ganaraters;
using System;

namespace Plugins
{
    public class CharGenerator : IGenerate
    {
        public Type GeneratedType => typeof(char);
        Random random = new Random();

        public object GetValue()
        {
            return (char)random.Next(65,90);
        }
    }
}
