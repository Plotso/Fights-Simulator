namespace Fights_Simulator.Miscellaneous
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public class FighterCreator
    {
        public Fighter CreateFighter(string name, int age, int height, double weight)
        {
            var fighter = new Fighter(name, age, height, weight, GenerateHealth(), GenerateEnergy(),
                GenerateSpeed(), GeneratePower(), GenerateAccuracy(), GenerateDeffence(), GenerateDiscipline(), GenerateIntelligence());
            return fighter;
        }

        
        public double GenerateHealth()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(20, 100));
        }

        public double GenerateEnergy()
        {
            //Random rnd = new Random();

            //return Convert.ToDouble(rnd.Next(50, 100));

            return 100;
        }

        public double GenerateSpeed()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(5, 100));
        }

        public double GeneratePower()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(1, 100));
        }

        public double GenerateAccuracy()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(10, 100));
        }

        public double GenerateDeffence()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(1, 100));
        }

        public int GenerateDiscipline()
        {
            Random rnd = new Random();

            return rnd.Next(1, 10);
        }

        public double GenerateIntelligence()
        {
            Random rnd = new Random();

            return Convert.ToDouble(rnd.Next(25, 100));
        }
    }
}
