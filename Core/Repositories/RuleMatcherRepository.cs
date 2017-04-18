using System.Collections.Generic;
using Core.Impl.BusinessRuleMatchers;
using Core.Interfaces;

namespace Core.Impl.Repositories
{
    public class BusinessRuleMatcherRepository:IBusinessRuleMatcherRepository
    {
        private readonly IProductTypeEvaluator _evaluator;

        public BusinessRuleMatcherRepository(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IReadOnlyCollection<IBusinessRuleMatcher> GetRuleMatchers()
        {
            return new IBusinessRuleMatcher[]
            {
                new DuplicatePackagingSlipForBookBusinessRuleMatcher(_evaluator),
                new PackagingSlipForLuxuryProductCommand(_evaluator),
                new PackagingSlipForPhysicalProductCommand(_evaluator),
                new ActivateMembershipBusinessRuleMatcher(_evaluator),
                new MembershipChangeEmailNotificationBusinessRuleMatcher(_evaluator),
                new UpgradeMembershipBusinessRuleMatcher(_evaluator), 
                new CourtDecisionNumber3417BusinessRuleMatcher(), 
                new InitiateAgentComissionPaymentBusinessRuleMatcher(_evaluator), 
            };
        }
    }
}
