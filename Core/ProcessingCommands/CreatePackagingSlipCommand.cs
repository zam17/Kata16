using System;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl.ProcessingCommands
{
    public class CreatePackagingSlipCommand : IProductBoundPurchaseProcessingCommand
    {
        public CreatePackagingSlipCommand(Purchase purchase, Product product)
        {
            Purchase = purchase;
            Product = product;
        }

        public Purchase Purchase { get; }
        public Product Product { get; }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}