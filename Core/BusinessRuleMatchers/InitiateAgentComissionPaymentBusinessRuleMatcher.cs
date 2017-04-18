using System.Linq;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;
using Core.Model;

namespace Core.Impl.BusinessRuleMatchers
{
    public class InitiateAgentComissionPaymentBusinessRuleMatcher: IBusinessRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;
         
        public InitiateAgentComissionPaymentBusinessRuleMatcher(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        // ReSharper disable once UnusedParameter.Local
        private Payment CalculateAgentsComissionPayment(Product[] productsWithComission)
        {
            // TODO: Make a call to a relevant subsystem.
            return new Payment();
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            Product[] productsWithComission = context.Purchase.Products
                .Where(p => _evaluator.IsBook(p) || _evaluator.IsPhysical(p))
                .ToArray();
            if (!productsWithComission.Any())
            {
                return new IPurchaseProcessingCommand[0];
            }
            Payment payment = CalculateAgentsComissionPayment(productsWithComission);
            InitiatePaymentCommand paymentCommand = new InitiatePaymentCommand(context.Purchase, payment);
            return new IPurchaseProcessingCommand[] { paymentCommand };
        }
    }
}
