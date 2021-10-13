using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ganaraters.PrimitiveTypeGenerator
{
    class DateTimeGenerator : IGenerate
    {
        private Random random = new Random();
        public Type GeneratedType => typeof(DateTime);

        public object GetValue()
        {
            /* generated values are limited according to DateTime limitations */
            int year = random.Next(DateTime.MinValue.Year, DateTime.MaxValue.Year + 1);
            int month = random.Next(1, 13);
            int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);
            int hour = random.Next(0, 24);
            int minute = random.Next(0, 60);
            int second = random.Next(0, 60);
            int millisecond = random.Next(0, 1000);

            return new DateTime(year, month, day, hour, minute, second, millisecond);
        }
    }
}
