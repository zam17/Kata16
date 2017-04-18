using System;
using System.Linq;
using Core.Impl;
using Core.Impl.ProcessingCommands;
using Core.Impl.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Model;
using Core.Interfaces;
using Core.Interfaces.Data;
using Moq;

namespace Core.Tests
{
    [TestClass]
    public class RulesProcessorTests
    {
        public RulesProcessorTests()
        {
            _product = new Product(new ProductCategory[0], ProductFlags.None, "Sample product");
            _purchase = new Purchase(new[] { _product }, new Payment());
        }

        private readonly Product _product;
        private readonly Purchase _purchase;

        [TestMethod]
        public void Returns_Empty_CommandsSet_For_Zero_Products_Purchase()
        {
            Mock<IBusinessRuleMatcherRepository> ruleMatcherRepositoryMock = new Mock<IBusinessRuleMatcherRepository>();
            ruleMatcherRepositoryMock.Setup(p => p.GetRuleMatchers()).Returns(new IBusinessRuleMatcher[0]);

            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(ruleMatcherRepositoryMock.Object, commandComparerRepository);
            Purchase emptyPurchase = new Purchase(new Product[0], new Payment());

            PurchaseCommandSet purchaseCommandsSet = rp.ProcessPurchase(emptyPurchase);

            Assert.AreEqual(0, purchaseCommandsSet.Commands.Count);
        }

        [TestMethod]
        public void Returns_CreateDuplicatePackingSlipCommand_For_Book_Purchase()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsBook(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            Assert.AreEqual(1, purchaseCommandSet.Commands.OfType<CreateDuplicatePackingSlipCommand>().Count());
        }

        [TestMethod]
        public void Returns_ActivateMembershipCommand_For_Book_Purchase()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsMembershipActivation(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            ActivateMembershipCommand[] activateMembership = purchaseCommandSet.Commands.OfType<ActivateMembershipCommand>().ToArray();
            Assert.AreEqual(1, activateMembership.Length);
        }

        [TestMethod]
        public void Returns_UpgradeMembershipCommand_For_Book_Purchase()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsMembershipActivation(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            Assert.AreEqual(1, purchaseCommandSet.Commands.Count);
            Assert.IsInstanceOfType(purchaseCommandSet.Commands.Single(), typeof(ActivateMembershipCommand));
        }

        [TestMethod]
        public void Returns_CreatePackagingSlipCommand_For_Book_Purchase()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsPhysical(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            Assert.AreEqual(1, purchaseCommandSet.Commands.OfType<CreatePackagingSlipCommand>().Count());
        }

        [TestMethod]
        public void Returns_OnlyOneGenerateSlipCommand_For_Luxury_Book_Purchase()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsLuxury(_product)).Returns(true);
            evaluator.Setup(p => p.IsBook(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            Assert.AreEqual(1, purchaseCommandSet.Commands.OfType<CreatePackagingSlipCommand>().Count());
        }


        [TestMethod]
        public void Returns_MultipleCommands_For_Purchase_With_Single_Product_Matching_Multiple_BusinessRules()
        {
            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsPhysical(_product)).Returns(true);
            evaluator.Setup(p => p.IsBook(_product)).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(_purchase);

            Assert.IsTrue(purchaseCommandSet.Commands.Count > 1);
        }

        [TestMethod]
        public void Returns_CommandsBoundForDifferentProducts_For_PurchaseWithMultipleProducts()
        {
            Product product1 = new Product(new ProductCategory[0], ProductFlags.None, String.Empty);
            Product product2 = new Product(new ProductCategory[0], ProductFlags.None, String.Empty);

            Purchase purchase = new Purchase(new[] { product1, product2 }, new Payment());

            Mock<IProductTypeEvaluator> evaluator = new Mock<IProductTypeEvaluator>();
            evaluator.Setup(p => p.IsPhysical(product1)).Returns(true);
            evaluator.Setup(p => p.IsBook(It.IsAny<Product>())).Returns(true);

            IBusinessRuleMatcherRepository repository = new BusinessRuleMatcherRepository(evaluator.Object);
            ICommandComparerRepository commandComparerRepository = new CommandComparerRepository();
            PurchaseProcessor rp = new PurchaseProcessor(repository, commandComparerRepository);

            PurchaseCommandSet purchaseCommandSet = rp.ProcessPurchase(purchase);

            Assert.AreEqual(2, purchaseCommandSet.Commands.OfType<IProductBoundPurchaseProcessingCommand>().Select(p => p.Product).Distinct().Count());
        }
    }
}
