using System;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl.ProcessingCommands
{
    public class ActivateMembershipCommand : IProductBoundPurchaseProcessingCommand
    {
        public ActivateMembershipCommand(Purchase purchase, Product product)
        {
            Product = product;
            Purchase = purchase;
        }

        public Purchase Purchase { get; }
        public Product Product { get; }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}