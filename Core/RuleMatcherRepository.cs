using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;

namespace Core.Impl
{
    public class RuleMatcherRepository:IRuleMatcherRepository
    {
        private readonly IProductTypeEvaluator _evaluator;

        public RuleMatcherRepository(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IReadOnlyCollection<IRuleMatcher> GetRuleMatchers()
        {
            return new IRuleMatcher[]
            {
                new BookRuleMatcher(_evaluator)
            };
        }
    }
}
