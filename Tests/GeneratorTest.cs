using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFaker;
using System;
using System.Collections.Generic;
using Tests.TestClasses;

namespace Tests
{
    [TestClass]
    public class GeneratorTest
    {
        private readonly string path = "C:Users//kiril//OneDrive//Рабочий стол//Учеба//3 курс//СПП//lab2//Plugins//bin//Debug//net5.0//";
        [TestMethod]
        public void TestBaseGeneratorAndPlugin()
        {
            var faker = new Faker();
            int intTest = faker.Create<int>();
            System.Console.WriteLine(intTest);
            byte byteTest = faker.Create<byte>();
            System.Console.WriteLine(byteTest);
            sbyte sbyteTest = faker.Create<sbyte>();
            System.Console.WriteLine(sbyteTest);
            short shortTest= faker.Create<short>();
            System.Console.WriteLine(shortTest);
            ushort ushortTest = faker.Create<ushort>();
            System.Console.WriteLine(ushortTest);
            uint uintTest = faker.Create<uint>();
            System.Console.WriteLine(uintTest);
            long longT = faker.Create<long>();
            System.Console.WriteLine(longT);
            ulong ulongT = faker.Create<ulong>();
            System.Console.WriteLine(ulongT);
            float floatT = faker.Create<float>();
            System.Console.WriteLine(floatT);
            double doubleT = faker.Create<double>();
            System.Console.WriteLine(doubleT);
            decimal decimalT = faker.Create<decimal>();
            System.Console.WriteLine(decimalT);
            char charTest = faker.Create<char>();
            System.Console.WriteLine(charTest);
            string stringTest = faker.Create<string>();
            System.Console.WriteLine(stringTest);
            DateTime dateTime = faker.Create<DateTime>();
            System.Console.WriteLine(dateTime);
            Assert.IsTrue(true);
            
        }

        [TestMethod]
        public void TestGenericGenerator()
        {
            var faker = new Faker();
            List<List<bool>> listlist = faker.Create<List<List<bool>>>();

            List<byte> list = faker.Create<List<byte>>();
            foreach (int el in list)
            {
                System.Console.WriteLine(el);
            }

            int[] array = faker.Create<int[]>();
            for (int i=0; i < array.Length; i++)
            {
                System.Console.WriteLine(array[i]);
            }

            
            float[] arrayF = faker.Create<float[]>();
            for (int i = 0; i < arrayF.Length; i++)
            {
                System.Console.WriteLine(arrayF[i]);
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TestClassesMethod()
        {
            var faker = new Faker();
            PublicPropertyAndField onlyProperties = faker.Create<PublicPropertyAndField>();
            PrivateConstructor privateConstructor = faker.Create<PrivateConstructor>();
            PrivateField privateField = faker.Create<PrivateField>();
            A a = faker.Create<A>();
            
            Assert.IsTrue(onlyProperties != null && privateConstructor == null && privateField != null && a.b.a == null);
        }
    }
}
