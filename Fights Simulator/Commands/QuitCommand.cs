namespace Fights_Simulator.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fights_Simulator.Core;
    using Fights_Simulator.Interfaces;

    public class QuitCommand : AbstractCommand
    {
        public QuitCommand(IList<string> args, IManager manager) : base(args, manager)
        {
        }

        public override string Execute()
        {
            return base.Manager.Quit(Args);
        }
    }
}
