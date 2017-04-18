using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Impl.ProcessingCommands;
using Core.Interfaces;
using Core.Interfaces.Data;

namespace Core.Impl.BusinessRuleMatchers
{
    public class UpgradeMembershipBusinessRuleMatcher: IBusinessRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;

        public UpgradeMembershipBusinessRuleMatcher(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IPurchaseProcessingCommand[] ret = context.Purchase.Products.Where(p => _evaluator.IsMembershipUpgrade(p))
                .Select(p => new UpgradeMembershipCommand(context.Purchase, p)).ToArray();
            return ret;
        }
    }
}
