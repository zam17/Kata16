using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IRuleMatcherRepository
    {
        IReadOnlyCollection<IRuleMatcher> GetRuleMatchers();
    }
}