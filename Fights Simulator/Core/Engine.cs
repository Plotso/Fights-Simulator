namespace Fights_Simulator.Core
{
    using Fights_Simulator.Interfaces;
    using Fights_Simulator.Commands;
    using Fights_Simulator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        private FighterManager fighterManager;
        

        public Engine()
        {
            this.fighterManager = new FighterManager();
        }
        public void Run()
        {
            bool isRunning = true;

            ShowCommandsExample();
            Console.WriteLine("Type command: )");
            while (isRunning)
            {
                string input = Console.ReadLine();
                //while (!input.StartsWith("Create"))
                //{
                //    Console.WriteLine("Please first create your fighter :)");
                //    input = Console.ReadLine();
                //}
                List<string> arguments = this.ParseInput(input);
                Console.WriteLine(this.ProcessInput(arguments));
                isRunning = !this.ShouldEnd(input);
            }




            //Console.WriteLine("Enter number of fighters(integer):");
            //var numberOfFighters = int.Parse(Console.ReadLine());
            //while (numberOfFighters != 2 && numberOfFighters != 4 && numberOfFighters != 8
            //       && numberOfFighters != 16 && numberOfFighters != 32 && numberOfFighters != 64)
            //{
            //    Console.WriteLine("Fighters should be either 2,4,8,16,32 or 64!");
            //    numberOfFighters = int.Parse(Console.ReadLine());
            //}

            //FightersGenerator fightersGenerator = new FightersGenerator();
            //Fighter[] fighters = new Fighter[numberOfFighters];
            //Console.WriteLine("Enter fighter's name and age.");
            //Console.WriteLine("Have in mind that if fighter's age is over 55 he will immediately retire and won't be usable");
            //Console.WriteLine("Input should be on a single line separated by a single space. Example: {name} {age}");
            //for (int i = 0; i < numberOfFighters; i++)
            //{

            //    var inputParams = Console.ReadLine().Split();
            //    var name = inputParams[0];
            //    var age = int.Parse(inputParams[1]);
            //    fighters[i] = fightersGenerator.GenerateFighter(name, age);
            //}

            //Console.WriteLine($"Currently there are {fighters.Length} pros registered!");
            //foreach (var fighter in fighters)
            //{
            //    Console.WriteLine(fighter);
            //}
            //Console.WriteLine();

            //Tournament tournament = new Tournament(fighters);
            //tournament.Start();
            //Console.WriteLine();
        }

        private void ShowCommandsExample()
        {
            StringBuilder sb = new StringBuilder();
            //We can make option to add consumables too
            sb.AppendLine("Welcome to Fighters Simulator! ");
            sb.AppendLine("We hope you have a lot of good and fun experience with our new game.");
            sb.AppendLine("So, in order to play the game you should know some basic commands:");
            sb.AppendLine("In order to begin you professional experience in the fighting environment, you must first create a fighter!");
            sb.AppendLine(">Create {Name} -> you will be send further to edit the info of the fighter you're up to create with the given name");
            sb.AppendLine(">Add Item -> well, you will choose and buy item to your fighter in order to improve his stats");
            sb.AppendLine(">Inspect Fighter -> get overall info about your fighter");
            sb.AppendLine(">Inspect Fighter Inventory -> get info about what items do your fighter contain");
            sb.AppendLine(">Help -> you'll be shown the list with commands once again");
            sb.AppendLine(">Quit -> quit the game / and lose everything simply because we don't have DB yet :D /");

            Console.WriteLine(sb.ToString());
        }

        private string ProcessInput(List<string> arguments)
        {
            string command = arguments[0];
            arguments.RemoveAt(0);

            if (command == "Create" && fighterManager.fightersCreated == 1)
            {
                return "You have already created a fighter!";
            }
            Type commandType = Type.GetType("Fights_Simulator.Commands" + "." + command + "Command");
            var constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
            ICommand cmd = (ICommand)constructor.Invoke(new object[] { arguments, this.fighterManager });
            return cmd.Execute();
        }
        //fix the error that occurs at line 99 -> nullreference

        private List<string> ParseInput(string input)
        {
            return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private bool ShouldEnd(string input)
        {
            return input.Equals("Quit");
        }
    }
}
