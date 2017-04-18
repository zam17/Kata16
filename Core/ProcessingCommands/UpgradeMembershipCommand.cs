using System;
using Core.Interfaces;
using Core.Model;

namespace Core.Impl.ProcessingCommands
{
    public class UpgradeMembershipCommand : IPurchaseProcessingCommand
    {
        public UpgradeMembershipCommand(Purchase purchase, Product membership)
        {
            Membership = membership;
            Purchase = purchase;
        }

        public Purchase Purchase { get; }
        public Product Membership { get; }

        public void Process()
        {
            throw new NotImplementedException();
        }
    }
}