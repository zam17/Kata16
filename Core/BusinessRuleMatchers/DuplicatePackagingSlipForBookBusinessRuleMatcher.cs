using System.Linq;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;

namespace Core.Impl.BusinessRuleMatchers
{
    public class DuplicatePackagingSlipForBookBusinessRuleMatcher : IBusinessRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;

        public DuplicatePackagingSlipForBookBusinessRuleMatcher(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IPurchaseProcessingCommand[] ret = context.Purchase.Products.Where(p => _evaluator.IsBook(p))
                .Select(p => new CreateDuplicatePackingSlipCommand(context.Purchase, p)).ToArray();
            return ret;
        }
    }
}