using Core.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Model;
using Core.Interfaces;

namespace Core.Tests
{
    [TestClass]
    public class RulesProcessorTests
    {
        [TestMethod]
        public void Returns_Empty_CommandsSet_For_Zero_Products_Payment()
        {
            PaymentProcessor rp = new PaymentProcessor();
            Payment emptyPayment = new Payment();
            CommandSet commandsSet = rp.ProcessPayment(emptyPayment);

            Assert.AreEqual(0, commandsSet.Commands.Count);
        }
    }
}
