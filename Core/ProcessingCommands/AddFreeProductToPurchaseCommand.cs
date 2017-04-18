using System;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl.ProcessingCommands
{
    public class AddFreeProductToPurchaseCommand : IPurchaseProcessingCommand
    {
        public AddFreeProductToPurchaseCommand(Purchase purchase, Product productToAdd)
        {
            Purchase = purchase;
            ProductToAdd = productToAdd;
        }

        public Purchase Purchase { get; }
        public Product ProductToAdd { get; }

        public void Process()

        {
            throw new NotImplementedException();
        }
    }
}