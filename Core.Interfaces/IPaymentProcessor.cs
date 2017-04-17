using Core.Model;

namespace Core.Interfaces
{
    public interface IPaymentProcessor
    {
        CommandSet ProcessPayment(Payment payment);
    }
}
