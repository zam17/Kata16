using Core.Model;

namespace Core.Interfaces
{
    public interface IRuleMatcher
    {
        IPaymentProcessingCommand[] MatchPaymentCommands(Payment payment);
    }
}