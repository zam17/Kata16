using System.Collections.Generic;
using Core.Model;

namespace Core.Interfaces
{
    public interface IRuleMatcher
    {
        IReadOnlyCollection<IPaymentProcessingCommand> MatchPaymentCommands(Payment payment);
    }
}