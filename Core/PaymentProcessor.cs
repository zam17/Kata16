using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Model;

namespace Core.Impl
{
    public class PaymentProcessor: IPaymentProcessor
    {
        private readonly IRuleMatcherRepository _ruleMatcherRepository;

        public PaymentProcessor(IRuleMatcherRepository ruleMatcherRepository)
        {
            _ruleMatcherRepository = ruleMatcherRepository;
        }

        public PaymentCommandSet ProcessPayment(Payment payment)
        {
            IReadOnlyCollection<IRuleMatcher> ruleMatchers = _ruleMatcherRepository.GetRuleMatchers();
            IPaymentProcessingCommand[] commands = ruleMatchers.SelectMany(p => p.MatchPaymentCommands(payment)).ToArray();
            PaymentCommandSet ret =  new PaymentCommandSet(commands, payment);
            return ret;
        }
    }
}
