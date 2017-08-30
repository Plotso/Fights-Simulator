namespace Fights_Simulator.Models.Items
{
    public class Boots : AbstractItem
    {
        public Boots(string name, bool hasSpecialEffect, double powerBonus, double speedBonus,
            double IntelligenceBonus, double deffenceBonus, double accuracyBonus) 
            : base(name, hasSpecialEffect, powerBonus, speedBonus, IntelligenceBonus, deffenceBonus, accuracyBonus)
        {
            base.Type = "Boots";
        }
    }
}
