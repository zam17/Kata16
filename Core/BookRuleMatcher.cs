using System.Linq;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl
{
    public class BookRuleMatcher : IRuleMatcher
    {
        private readonly IProductTypeEvaluator _evaluator;

        public BookRuleMatcher(IProductTypeEvaluator evaluator)
        {
            _evaluator = evaluator;
        }

        public IPaymentProcessingCommand[] MatchPaymentCommands(Payment payment)
        {
            IPaymentProcessingCommand[] ret = payment.Products.Where(p => _evaluator.IsBook(p))
                .Select(p => new CreatePackingSlipCommand(p)).ToArray();
            return ret;
        }
    }
}