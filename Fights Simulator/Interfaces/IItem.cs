namespace Fights_Simulator.Interfaces
{
    public interface IItem
    {
        string Name { get; }


        double PowerBonus { get; }

        double SpeedBonus { get; }

        double IntelligenceBonus { get; }

        double DeffenceBonus { get; }

        double AccuracyBonus { get; }

        bool HasSpecialEffect { get; }

        double WearLevel { get; }

        void DecreaseWearLevel(double wearAmount);
    }
}
