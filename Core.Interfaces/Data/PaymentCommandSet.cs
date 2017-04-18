using System.Collections.Generic;
using Core.Model;

namespace Core.Interfaces.Data
{
    public class PurchaseCommandSet
    {
        public PurchaseCommandSet(IReadOnlyCollection<IPurchaseProcessingCommand> commands, Purchase purchase)
        {
            Commands = commands;
            Purchase = purchase;
        }

        public Purchase Purchase { get; }

        public IReadOnlyCollection<IPurchaseProcessingCommand> Commands { get; }
    }
}