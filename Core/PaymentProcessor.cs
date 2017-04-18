using Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Core.Interfaces.Data;
using Core.Model;

namespace Core.Impl
{
    public class PurchaseProcessor : IPurchaseProcessor
    {
        private readonly IBusinessRuleMatcherRepository _businessRuleMatcherRepository;
        private readonly ICommandComparerRepository _commandComparerRepository;

        public PurchaseProcessor(IBusinessRuleMatcherRepository businessRuleMatcherRepository, ICommandComparerRepository commandComparerRepository)
        {
            _businessRuleMatcherRepository = businessRuleMatcherRepository;
            _commandComparerRepository = commandComparerRepository;
        }

        public PurchaseCommandSet ProcessPurchase(Purchase purchase)
        {
            PurchaseBusinessRulesProcessingContext context = new PurchaseBusinessRulesProcessingContext(purchase);
            IReadOnlyCollection<IBusinessRuleMatcher> ruleMatchers = _businessRuleMatcherRepository.GetRuleMatchers();

            CreateCommands(ruleMatchers, context);
            var filteredCommands = FilterCommands(context);

            PurchaseCommandSet ret = new PurchaseCommandSet(filteredCommands, purchase);
            return ret;
        }

        private static void CreateCommands(IReadOnlyCollection<IBusinessRuleMatcher> ruleMatchers, PurchaseBusinessRulesProcessingContext context)
        {
            foreach (IBusinessRuleMatcher matcher in ruleMatchers)
            {
                IPurchaseProcessingCommand[] commands = matcher.MatchPurchaseCommands(context);
                context.AddCommands(commands);
            }
        }

        // Some of the commands should only be applied once per product or once per purchase etc.
        // Putting this logic into business rule matchers would violate SRP, since each business rule matcher should take 
        // care only of a particular case for particular command, not for particular command as a whole.
        // We need another layer taking care of removing duplicate commands. Multiple approaches can be taken here,
        // for this Kata purpose I'm using a simple approach with comparer. 
        // This method serves as an extension point and can easily be altered later to include more complex rules and checks.
        private IPurchaseProcessingCommand[] FilterCommands(PurchaseBusinessRulesProcessingContext context)
        {
            IPurchaseProcessingCommand[] filteredCommands = context.Commands.ToArray();
            IReadOnlyCollection<IPurchaseProcessingCommandComparer> comparers = _commandComparerRepository.GetRuleComparers();
            foreach (IPurchaseProcessingCommandComparer comparer in comparers)
            {
                filteredCommands = comparer.Filter(filteredCommands);
            }
            return filteredCommands;
        }
    }
}
