using System.Collections.Generic;
using Core.Interfaces.Data;
using Core.Model;

namespace Core.Interfaces
{
    public interface IBusinessRuleMatcher
    {
        IPurchaseProcessingCommand[] MatchPurchaseCommands(PurchaseBusinessRulesProcessingContext context);
    }
}