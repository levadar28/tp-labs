namespace lab5
{
    public class AnimalWeightAdapter : IAnimalWeight
    {
        private readonly OldClinicSystem oldSystem;

        public AnimalWeightAdapter(OldClinicSystem oldSystem)
        {
            this.oldSystem = oldSystem;
        }

        public double GetWeightKg()
        {
            double pounds = oldSystem.ReadPounds();

            return pounds * 0.45359237;
        }
    }
}