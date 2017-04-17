using System.Collections.Generic;

namespace Core.Interfaces
{
    public class CommandSet
    {
        public CommandSet(IPaymentProcessingCommand[] commands)
        {
            Commands = commands;
        }

        public IReadOnlyCollection<IPaymentProcessingCommand> Commands { get; }
    }
}