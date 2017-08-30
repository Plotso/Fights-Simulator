namespace Fights_Simulator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;

    public class Tournament
    {
        private Fighter[] participants;
        private double entryFee;
        private double prize;

        public Tournament(Fighter[] participatingFighters)
        {
            this.ParticipatingFighters = participatingFighters;
        }

        public Fighter[] ParticipatingFighters
        {
            get { return this.participants; }
            set { this.participants = value; }
        }

        public double EntryFee
        {
            get => this.entryFee;
            set => this.entryFee = value;
        }
        public double Prize
        {
            get => this.prize;
            //set => this.prize = value;
        }

        public void Start()
        {
            var fighters = new List<Fighter>();
            foreach (var participant in participants)
            {
                fighters.Add(participant);
            }

            var count = 1;

            while (fighters.Count != 2)
            {
                Console.WriteLine($"It is matchday {count}");
                Dictionary<Fighter, Fighter> pairs = GeneratePairs(fighters);
                fighters = SumFights(pairs);

                count++;
            }

            Console.WriteLine("It is the GRAND FINAL!");
            Dictionary<Fighter, Fighter> finalPair = GeneratePairs(fighters);
            var winner = Fight(fighters[0], fighters[1]);
            winner.TrophiesWon++;
            //fighters.Remove(winner);
            //fighters[0].SecondPlaces
            Console.WriteLine($"The winner is {winner.Name}({winner.Age}) with {winner.Energy} energy remaining remaining.Trophies won: {winner.TrophiesWon}");

        }

        private List<Fighter> SumFights(Dictionary<Fighter, Fighter> pairs)
        {
            var winners = new List<Fighter>();

            foreach (var pair in pairs)
            {
                var fighter1 = pair.Key;
                var fighter2 = pair.Value;

                winners.Add(Fight(fighter1,fighter2));
            }
            if (winners.Count != 1)
            {
                Console.WriteLine($"Today's winners are : ");
                foreach (var winner in winners)
                {
                    Console.Write($"{winner.Name}({winner.Overall()}) ");
                }
                Console.WriteLine();
            }
            
            return winners;
        }

        private Fighter Fight(Fighter fighter1, Fighter fighter2)
        {
            double fighter1Overall = fighter1.Overall();
            double fighter2Overall = fighter2.Overall();

            if (fighter1Overall > fighter2Overall)
            {
                if (Difference(fighter1Overall, fighter2Overall) < 10)
                {
                    fighter1.Energy -= 25;
                }
                return fighter1;
            }
            else if (fighter2Overall < fighter1Overall)
            {
                if (Difference(fighter2Overall, fighter1Overall) < 10)
                {
                    fighter2.Energy -= 25;
                }
                return fighter2;
            }

            if (fighter1.Energy > fighter2.Energy)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Energy < fighter2.Energy)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Intelligence > fighter2.Intelligence)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Intelligence < fighter2.Intelligence)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Deffence > fighter2.Deffence)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Deffence < fighter2.Deffence)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Speed > fighter2.Speed)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Speed < fighter2.Speed)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Age < fighter2.Age)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Age > fighter2.Age)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Accuracy < fighter2.Accuracy)
            {
                fighter1.Energy -= 30;
                return fighter1;
            }
            else if (fighter1.Accuracy > fighter2.Accuracy)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }

            if (fighter1.Health < fighter2.Health)
            {
                fighter2.Energy -= 30;
                return fighter2;
            }
            fighter1.Energy -= 30;
            return fighter1;
        }

        private double Difference(double fighter1Overall, double fighter2Overall)
        {
            return  fighter1Overall - fighter2Overall;
        }

        private Dictionary<Fighter, Fighter> GeneratePairs(IList<Fighter> fighters)
        {
            if (fighters.Count > 2)
            {
                Console.WriteLine("Generating the pairs ");
            }
            else
            {
                Console.WriteLine("The pair for the final is:");
            }
            
            Dictionary<Fighter, Fighter> fightingCouples = new Dictionary<Fighter, Fighter>();
            Random rnd = new Random();
            int n = fighters.Count();

            Timer timer  = new Timer(2000);
            
            while (n > 1)
            {
                n--;

                int k = rnd.Next(n + 1);
                Fighter value = fighters[k];
                fighters[k] = fighters[n];
                fighters[n] = value;

            }

            for (int i = 0; i < fighters.Count; i += 2)
            {
                fightingCouples.Add(fighters[i], fighters[i + 1]);
            }

            foreach (var pair in fightingCouples)
            {
                var firstFighter = pair.Key.Name;
                var secondFighter = pair.Value.Name;
                Console.WriteLine($"{firstFighter}({pair.Key.Overall()}) vs {secondFighter}({pair.Value.Overall()})");
            }
            return fightingCouples;
        }
    }
}
