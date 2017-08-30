namespace Fights_Simulator.Interfaces
{
    using System.Collections.Generic;
    public interface IManager
    {
        string Quit(IList<string> arguments);

        string CreateFighter(IList<string> arguments);

        string DeleteFighter(IList<string> arguments);

        string Help(IList<string> arguments);
    }
}
