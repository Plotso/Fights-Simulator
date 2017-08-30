namespace Fights_Simulator.Commands
{
    using System.Collections.Generic;
    using Fights_Simulator.Interfaces;
    public class BuyCommand : AbstractCommand
    {
        public BuyCommand(IList<string> args, IManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.BuyItem(Args);
        }
    }
}
