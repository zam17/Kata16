using System.Collections.Generic;
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

        public IReadOnlyCollection<IPaymentProcessingCommand> MatchPaymentCommands(Payment payment)
        {
            CreateDuplicatePackingSlipCommand[] ret = payment.Products.Where(p => _evaluator.IsBook(p))
                .Select(p => new CreateDuplicatePackingSlipCommand(p)).ToArray();
            return ret;
        }
    }
}