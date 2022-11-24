using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestBuilder;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Greet greeting = new Greet();
            //greeting.TimeOfDay = "noche";
            //greeting.To = "Rogrigo";

            Greet greeting = GreetingBuilder
                .CreateNew()
                .TimeOfDay("Noches")
                .To("Rodrigo")
                .Build();

            Assert.AreEqual("Buenas Noches Rodrigo", greeting.Message);
        }
    }
}