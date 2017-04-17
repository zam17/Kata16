using System.Collections.Generic;

namespace Core.Interfaces
{
    public class CommandSet
    {
        public CommandSet(ICommand[] commands)
        {
            Commands = commands;
        }

        public IReadOnlyCollection<ICommand> Commands { get; }
    }
}