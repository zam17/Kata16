using Core.Model;

namespace Core.Interfaces
{
    public interface IPaymentProcessor
    {
        PaymentCommandSet ProcessPayment(Payment payment);
    }
}
