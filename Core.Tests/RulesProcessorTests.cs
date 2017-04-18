using System.Linq;
using Core.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Model;
using Core.Interfaces;
using Moq;

namespace Core.Tests
{
    [TestClass]
    public class RulesProcessorTests
    {
        [TestMethod]
        public void Returns_Empty_CommandsSet_For_Zero_Products_Payment()
        {
            Mock<IRuleMatcherRepository> ruleMatcherRepositoryMock = new Moq.Mock<IRuleMatcherRepository>();
            ruleMatcherRepositoryMock.Setup(p => p.GetRuleMatchers()).Returns(new IRuleMatcher[0]);

            PaymentProcessor rp = new PaymentProcessor(ruleMatcherRepositoryMock.Object);
            Payment emptyPayment = new Payment(new Product[0], new PaymentOption(), new PaymentSum());

            PaymentCommandSet paymentCommandsSet = rp.ProcessPayment(emptyPayment);

            Assert.AreEqual(0, paymentCommandsSet.Commands.Count);
        }

        [TestMethod]
        public void Returns_GeneratePackingSlip_For_Book_Payment()
        {
            IProductTypeEvaluator evaluator = new ProductTypeEvaluator();
            IRuleMatcherRepository repository = new RuleMatcherRepository(evaluator);
            PaymentProcessor rp = new PaymentProcessor(repository);

            Product book = new Product(new [] {new ProductCategory("Books")}, ProductFlags.None);
            Payment bookPayment = new Payment(new [] {book}, new PaymentOption(), new PaymentSum());

            PaymentCommandSet paymentCommandSet = rp.ProcessPayment(bookPayment);

            Assert.AreEqual(1, paymentCommandSet.Commands.Count);
            Assert.IsInstanceOfType(paymentCommandSet.Commands.Single(), typeof(CreateDuplicatePackingSlipCommand));
        }
    }
}
