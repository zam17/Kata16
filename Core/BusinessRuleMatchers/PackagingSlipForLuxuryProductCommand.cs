using System.Linq;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;

namespace Core.Impl.BusinessRuleMatchers
{
    /// <summary>
    /// This rule is not in the original Kata 16 assignment.
    /// I added it to tackle the interesting problem when there are separate rules that trigger
    /// the same action and this creates a need to remove duplication of commands.
    /// </summary>
    public class PackagingSlipForLuxuryProductCommand : IBusinessRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;

        public PackagingSlipForLuxuryProductCommand(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IPurchaseProcessingCommand[] ret = context.Purchase.Products.Where(p => _evaluator.IsLuxury(p))
                .Select(p => new CreatePackagingSlipCommand(context.Purchase, p)).ToArray();
            return ret;
        }
    }
}