using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyFaker;

namespace Tests
{
    [TestClass]
    public class GeneratorTest
    {
        private readonly string path = "C:Users//kiril//OneDrive//Рабочий стол//Учеба//3 курс//СПП//lab2//Plugins//bin//Debug//net5.0//";
        [TestMethod]
        public void TestGeneratorAndPlugin()
        {
            var faker = new Faker();
            int intTest = faker.Create<int>();
            System.Console.WriteLine(intTest);
            byte byteTest = faker.Create<byte>();
            System.Console.WriteLine(byteTest);
            char charTest = faker.Create<char>();
            System.Console.WriteLine(charTest);
            string stringTest = faker.Create<string>();
            System.Console.WriteLine(stringTest);
            Assert.IsTrue(true);
        }
    }
}
