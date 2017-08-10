namespace Fights_Simulator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Fights_Simulator.Models;

    public class StartUp
    {
        public static void Main()
        {
            Console.WriteLine("Enter number of fighters(integer):");
            var numberOfFighters = int.Parse(Console.ReadLine());
            while (numberOfFighters != 2 && numberOfFighters != 4 && numberOfFighters != 8
                   && numberOfFighters != 16 && numberOfFighters != 32 && numberOfFighters != 64)
            {
                Console.WriteLine("Fighters should be either 2,4,8,16,32 or 64!");
                numberOfFighters = int.Parse(Console.ReadLine());
            }

            FightersGenerator fightersGenerator = new FightersGenerator();
            Fighter[] fighters = new Fighter[numberOfFighters];
            Console.WriteLine("Enter fighter's name and age.");
            Console.WriteLine("Have in mind that if fighter's age is over 55 he will immediately retire and won't be usable");
            Console.WriteLine("Input should be on a single line separated by a single space. Example: {name} {age}");
            for (int i = 0; i < numberOfFighters; i++)
            {
                
                var inputParams = Console.ReadLine().Split();
                var name = inputParams[0];
                var age = int.Parse(inputParams[1]);
                fighters[i] = fightersGenerator.GenerateFighter(name, age);
            }

            Console.WriteLine($"Currently there are {fighters.Length} pros registered!");
            foreach (var fighter in fighters)
            {
                Console.WriteLine(fighter);
            }
            Console.WriteLine();

            Tournament tournament = new Tournament(fighters);
            tournament.Start();
            Console.WriteLine();
        }
    }
}
