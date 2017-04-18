using System.Collections.Generic;
using Core.Model;

namespace Core.Interfaces.Data
{
    public class PurchaseBusinessRulesProcessingContext
    {
        private readonly List<IPurchaseProcessingCommand> _commands = new List<IPurchaseProcessingCommand>();

        public PurchaseBusinessRulesProcessingContext(Purchase purchase)
        {
            Purchase = purchase;
        }

        public IReadOnlyCollection<IPurchaseProcessingCommand> Commands => _commands;

        public void AddCommands(params IPurchaseProcessingCommand[] newCommands)
        {
            _commands.AddRange(newCommands);
        }

        public Purchase Purchase { get; }
    }
}
