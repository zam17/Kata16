using System.Collections.Generic;
using Core.Impl.BusinessRuleComparers;
using Core.Interfaces;

namespace Core.Impl.Repositories
{
    public class CommandComparerRepository:ICommandComparerRepository
    {
        public IReadOnlyCollection<IPurchaseProcessingCommandComparer> GetRuleComparers()
        {
            return new IPurchaseProcessingCommandComparer[]
            {
                new ProductBoundPurchaseProcessingCommandComparer<IProductBoundPurchaseProcessingCommand>(),
            };
        }
    }
}
