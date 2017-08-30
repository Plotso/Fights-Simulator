namespace Fights_Simulator.Commands
{
    using System.Collections.Generic;
    using Fights_Simulator.Core;
    using Fights_Simulator.Interfaces;

    public class CreateCommand : AbstractCommand
    {
        public CreateCommand(IList<string> args, IManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.CreateFighter(Args);
        }
    }
}
