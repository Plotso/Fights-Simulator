namespace Fights_Simulator.Models.Items
{
    public class Gloves : AbstractItem
    {
        public Gloves(string name, bool hasSpecialEffect, double powerBonus, double speedBonus,
            double IntelligenceBonus, double deffenceBonus, double accuracyBonus) 
            : base(name, hasSpecialEffect, powerBonus, speedBonus, IntelligenceBonus, deffenceBonus, accuracyBonus)
        {
            base.Type = "Gloves";
        }
    }
}
