using System.Collections.Generic;
using System.Linq;
using Core.Interfaces;

namespace Core.Impl.BusinessRuleComparers
{
    /// <summary>
    /// All product bound commands are considered to be only applicable once by default.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ProductBoundPurchaseProcessingCommandComparer<T> : IPurchaseProcessingCommandComparer
        where T : IProductBoundPurchaseProcessingCommand
    {
        public IPurchaseProcessingCommand[] Filter(IPurchaseProcessingCommand[] commands)
        {
            IEnumerable<T> commandsOfType = commands.OfType<T>();
            IEnumerable<IPurchaseProcessingCommand> commandsToExlcude = commandsOfType.GroupBy(p =>new { p.Product, t=p.GetType()}).SelectMany(p => p.Skip(1)).Cast<IPurchaseProcessingCommand>();
            IPurchaseProcessingCommand[] ret = commands.Except(commandsToExlcude).ToArray();

            return ret;
        }
    }
}
