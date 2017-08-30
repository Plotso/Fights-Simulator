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
        private Shop shop;
        private int playerFighterId;

        public FighterManager()
        {
            this.fighters = new Dictionary<int, Fighter>();
            this.shop = new Shop();
            FillShop();
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

        public string InspectFighter(IList<string> arguments)
        {
            string result = "";
            try
            {
                string fighterName = arguments[0];
                var foundFightersId = new List<int>();
                foreach (var fighter in fighters)
                {
                    if (fighter.Value.Name == fighterName)
                    {
                        foundFightersId.Add(fighter.Key);
                    }
                }
                if (foundFightersId.Count == 0)
                {
                    Console.WriteLine($"There isn't any player named {fighterName}");
                    result = "Please insert a new command";
                }
                else if (foundFightersId.Count > 1)
                {
                    Console.WriteLine($"We found {foundFightersId.Count} players with the given name");
                    Console.WriteLine($"Please choose which one do you want to inspect: ");
                    for (int i = 1; i <= foundFightersId.Count; i++)
                    {
                        int fighterId = foundFightersId[i - 1];
                        Console.WriteLine($"{i}. {fighters[fighterId].ToString()}");
                        Console.WriteLine();
                    }
                    var number = int.Parse(Console.ReadLine());

                    int id = foundFightersId[number - 1];
                    result = $"{fighters[id].FighterInfo()}";
                }
                else
                {
                    int id = foundFightersId[0];
                    StringBuilder sb = new StringBuilder();
                    //sb.AppendLine($"{fighters[id].ToString()}");
                    sb.AppendLine($"{fighters[id].FighterInfo()}");
                    result = sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public string DeleteFighter(IList<string> arguments)
        {
            string result = "";
            try
            {
                string fighterName = arguments[0];
                var foundFightersId = new List<int>();
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

        public string BuyItem(IList<string> arguments)
        {
            string result = "";
            try
            {
                Console.WriteLine("Here are the items currently available");
                var counter = 1;
                foreach (var item in shop.Items)
                {
                    Console.WriteLine($"{counter}" + item.ToString());
                    counter++;
                }
                Console.WriteLine("Please enter the item number which you want to buy");
                var num = int.Parse(Console.ReadLine());
                fighters[playerFighterId].AddItem(shop.Items[num - 1]);
                result = $"{shop.Items[num - 1].Name} added";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return result;
        }

        public string Help(IList<string> arguments)
        {
            StringBuilder sb = new StringBuilder();
            //We can make option to add consumables too
            sb.AppendLine("In order to begin you professional experience in the fighting environment, you must first create a fighter!");
            sb.AppendLine("Commands:");
            sb.AppendLine(">Create {Name} -> you will be send further to edit the info of the fighter you're up to create with the given name");
            sb.AppendLine(">Buy -> well, you will choose and buy item to your fighter in order to improve his stats");
            sb.AppendLine(">Inspect Fighter -> get overall info about your fighter");
            sb.AppendLine(">Inspect Fighter Inventory -> get info about what items do your fighter contain");
            sb.AppendLine(">Delete Fighter -> delete the fighter with that name ");
            sb.AppendLine(">Help -> you'll be shown the list with commands once again");
            sb.AppendLine(">Quit -> quit the game / and lose everything simply because we don't have DB yet :D /");

            return sb.ToString();
        }

        public string Quit(IList<string> arguments)
        {
            Fighter fighter = fighters[playerFighterId];

            return fighter.FighterInfo();
        }


        private void FillShop()
        {
            shop.AddBasicItems();
        }
    }
}
