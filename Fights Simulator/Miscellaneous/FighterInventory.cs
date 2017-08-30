namespace Fights_Simulator.Miscellaneous
{
    using Fights_Simulator.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FighterInventory
    {
        [Item]
        private Dictionary<string, IItem> fighterItems;

        public FighterInventory()
        {
            this.fighterItems = new Dictionary<string, IItem>();
        }

        public double TotalPowerBonus
        {
            get { return this.fighterItems.Values.Sum(i => (double)i.PowerBonus); }
        }

        public double TotalSpeedBonus
        {
            get { return this.fighterItems.Values.Sum(i => (double)i.SpeedBonus); }
        }

        public double TotalIntelligenceBonus
        {
            get { return this.fighterItems.Values.Sum(i => (double)i.IntelligenceBonus); }
        }

        public double TotalDefenceBonus
        {
            get { return this.fighterItems.Values.Sum(i => (double)i.DeffenceBonus); }
        }

        public double TotalAccuracyBonus
        {
            get { return this.fighterItems.Values.Sum(i => (double)i.AccuracyBonus); }
        }

        public void AddItem(IItem item)
        {
            if (fighterItems.ContainsKey(item.Name))
            {
                throw new ArgumentException("The given item is already in the inventory");
            }
            this.fighterItems.Add(item.Name, item);
        }
    }
}
