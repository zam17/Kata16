using System.Collections.Generic;
using Core.Model;

namespace Core.Interfaces
{
    public class PaymentCommandSet
    {
        public PaymentCommandSet(IPaymentProcessingCommand[] commands, Payment payment)
        {
            Commands = commands;
            Payment = payment;
        }

        public Payment Payment { get; }

        public IReadOnlyCollection<IPaymentProcessingCommand> Commands { get; }
    }
}