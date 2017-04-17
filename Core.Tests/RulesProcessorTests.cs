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
            var ruleMatcherRepositoryMock = new Moq.Mock<IRuleMatcherRepository>();
            ruleMatcherRepositoryMock.Setup(p => p.GetRuleMatchers()).Returns(new IRuleMatcher[0]);

            PaymentProcessor rp = new PaymentProcessor(ruleMatcherRepositoryMock.Object);
            Payment emptyPayment = new Payment();
            CommandSet commandsSet = rp.ProcessPayment(emptyPayment);

            Assert.AreEqual(0, commandsSet.Commands.Count);
        }
    }
}
