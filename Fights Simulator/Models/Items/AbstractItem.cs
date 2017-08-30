using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fights_Simulator.Models.Items
{
    using Fights_Simulator.Interfaces;

    public class AbstractItem : IItem
    {
        public AbstractItem(string name, bool hasSpecialEffect, double powerBonus, double speedBonus, double IntelligenceBonus,
            double deffenceBonus, double accuracyBonus)
        {
            this.Name = name;
            this.Type = "";
            this.HasSpecialEffect = hasSpecialEffect;
            this.PowerBonus = powerBonus;
            this.SpeedBonus = speedBonus;
            this.IntelligenceBonus = IntelligenceBonus;
            this.DeffenceBonus = deffenceBonus;
            this.AccuracyBonus = accuracyBonus;
            
            this.WearLevel = 100;
        }
        public string Name { get; private set; }

        public string Type { get; protected set; }

        public bool HasSpecialEffect { get; private set; }

        public double WearLevel { get; private set; }

        public double PowerBonus { get; private set; }

        public double SpeedBonus { get; private set; }

        public double IntelligenceBonus { get; private set; }

        public double DeffenceBonus { get; private set; }

        public double AccuracyBonus { get; private set; }

        public void DecreaseWearLevel(double wearAmount)
        {
            this.WearLevel -= wearAmount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"###Item: {this.Name}");
            sb.AppendLine($"##+{this.PowerBonus} Power");
            sb.AppendLine($"##+{this.SpeedBonus} Speed");
            sb.AppendLine($"##+{this.IntelligenceBonus} Intelligence");
            sb.AppendLine($"##+{this.DeffenceBonus} Deffence");
            sb.AppendLine($"##+{this.AccuracyBonus} Accuracy");
            return sb.ToString();
        }
    }
}
