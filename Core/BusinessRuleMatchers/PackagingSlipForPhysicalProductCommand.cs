using System.Linq;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;

namespace Core.Impl.BusinessRuleMatchers
{
    public class PackagingSlipForPhysicalProductCommand : IBusinessRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;

        public PackagingSlipForPhysicalProductCommand(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IPurchaseProcessingCommand[] ret = context.Purchase.Products.Where(p => _evaluator.IsPhysical(p))
                .Select(p => new CreatePackagingSlipCommand(context.Purchase, p)).ToArray();
            return ret;
        }
    }
}