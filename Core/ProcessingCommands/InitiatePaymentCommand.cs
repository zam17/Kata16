using System;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl.ProcessingCommands
{
    public class InitiatePaymentCommand : IPurchaseProcessingCommand
    {
        public InitiatePaymentCommand(Purchase originalPurchase, Payment payment)
        {
            OriginalPurchase = originalPurchase;
            Payment = payment;
        }

        public Purchase OriginalPurchase { get; }
        public Payment Payment { get; }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}