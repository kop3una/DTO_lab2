using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFaker;

namespace Tests
{
    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var faker = new Faker();
            int intTest = faker.Create<int>();
            System.Console.WriteLine(intTest);
            byte byteTest = faker.Create<byte>();
            System.Console.WriteLine(byteTest);
            Assert.IsTrue(true);
        }
    }
}
