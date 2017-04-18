using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface ICommandComparerRepository
    {
        IReadOnlyCollection<IPurchaseProcessingCommandComparer> GetRuleComparers();
    }
}