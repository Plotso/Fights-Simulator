namespace Fights_Simulator.Core
{
    using Fights_Simulator.Interfaces;
    using Fights_Simulator.Miscellaneous;
    using Fights_Simulator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FighterManager : IManager
    {
        private Dictionary<int, Fighter> fighters;
        private int playerFighterId;

        public FighterManager()
        {
            this.fighters = new Dictionary<int, Fighter>();
        }

        public int NumberOfFighter => this.fighters.Count();

        public int fightersCreated;
        public string CreateFighter(IList<string> arguments)
        {
            string result = "";
            try
            {
                string fighterName = arguments[0];
                FighterCreator creator = new FighterCreator();
                Console.WriteLine($"Hello, let's add little more details about {fighterName}");
                Console.WriteLine($"How old is he?");
                var age = int.Parse(Console.ReadLine());
                Console.WriteLine($"What is {fighterName}'s height? (centimeters)");
                var height = int.Parse(Console.ReadLine());
                Console.WriteLine($"How much does {fighterName} weights? (kilograms)");
                var weight = double.Parse(Console.ReadLine());

                var id = NumberOfFighter;

                var fighter = creator.CreateFighter(fighterName, age, height, weight);
                this.fighters.Add(NumberOfFighter, fighter);
                Console.WriteLine("Done");

                this.playerFighterId = id;
                this.fightersCreated += 1;
                result = fighter.FighterInfo();
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return result;
        }

        public string DeleteFighter(IList<string> arguments)
        {
            string result = "";
            try
            {
                string fighterName = arguments[0];
                var foundFightersId = new List<int>();//fighters.Where(x => x.Value.Name == fighterName);
                foreach (var fighter in fighters)
                {
                    if (fighter.Value.Name == fighterName)
                    {
                        foundFightersId.Add(fighter.Key);
                    }
                }
                Console.WriteLine($"We found {foundFightersId.Count} player/s with the given name");
                if (foundFightersId.Count == 1)
                {
                    var id = foundFightersId[0];
                    if (playerFighterId != id)
                    {
                        throw new ArgumentException($"You don't have permission to remove {fighters[id].Name}." 
                            + Environment.NewLine +
                            $"You can only remove players that you have created!");
                    }
                    else
                    {
                        result = $"Fighter {fighters[id].Name} was successfully removed!";
                        fighters.Remove(id);
                        playerFighterId = -1;
                        fightersCreated--;
                    }
                }
                else if (foundFightersId.Count == 0)
                {
                    result = "Please insert a new command";
                }
                else
                {
                    var counter = 0;
                    foreach (var fighterId in foundFightersId)
                    {
                        if (playerFighterId == fighterId)
                        {
                            result = $"Fighter {fighters[fighterId].Name} was successfully removed!";
                            fighters.Remove(fighterId);
                            playerFighterId = -1;
                            fightersCreated--;

                            counter++;
                        }
                    }
                    if (counter == 0)
                    {
                        result = "None of the matches is a player that you've created, therefore, you are not allowed to delete any of them";
                    }
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            return result + Environment.NewLine;
        }

        public string Help(IList<string> arguments)
        {
            StringBuilder sb = new StringBuilder();
            //We can make option to add consumables too
            sb.AppendLine("In order to begin you professional experience in the fighting environment, you must first create a fighter!");
            sb.AppendLine("Commands:");
            sb.AppendLine(">Create {Name} -> you will be send further to edit the info of the fighter you're up to create with the given name");
            sb.AppendLine(">Add Item -> well, you will choose and buy item to your fighter in order to improve his stats");
            sb.AppendLine(">Inspect Fighter -> get overall info about your fighter");
            sb.AppendLine(">Inspect Fighter Inventory -> get info about what items do your fighter contain");
            sb.AppendLine(">Help -> you'll be shown the list with commands once again");
            sb.AppendLine(">Quit -> quit the game / and lose everything simply because we don't have DB yet :D /");

            return sb.ToString();
        }

        public string Quit(IList<string> arguments)
        {
            Fighter fighter = fighters[playerFighterId];

            return fighter.FighterInfo();
        }
    }
}
