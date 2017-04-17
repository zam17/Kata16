using Core.Model;

namespace Core.Interfaces
{
    public interface IRuleMatcher
    {
        ICommand[] MatchPaymentCommands(Payment payment);
    }
}