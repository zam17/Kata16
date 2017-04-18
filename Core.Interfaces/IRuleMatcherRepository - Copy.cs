using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IBusinessRuleMatcherRepository
    {
        IReadOnlyCollection<IBusinessRuleMatcher> GetRuleMatchers();
    }
}