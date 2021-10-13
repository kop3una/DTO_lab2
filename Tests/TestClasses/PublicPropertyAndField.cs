using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestClasses
{
    public class PublicPropertyAndField
    {
        public int SomeValue
        { get; set; }

        public int someValue;

        public string SomeString
        { get; set; }

        public List<List<bool>> listlist;
    }
}
