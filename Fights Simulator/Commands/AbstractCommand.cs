namespace Fights_Simulator.Commands
{
    using Fights_Simulator.Core;
    using Fights_Simulator.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public abstract class AbstractCommand : ICommand
    {
        public AbstractCommand(IList<string> args, IManager manager)
        {
            this.Args = args;
            this.Manager = manager;
        }

        public IList<string> Args { get; private set; }

        public IManager Manager { get; private set; }

        public abstract string Execute();
    }
}
