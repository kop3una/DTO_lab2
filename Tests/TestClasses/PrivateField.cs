using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.TestClasses
{
    class PrivateField
    {

        private int someValue;

        private string SomeString;

        public PrivateField()
        {

        }

        public PrivateField(int someValue)
        {
            this.someValue = someValue;
        }
    }
}
