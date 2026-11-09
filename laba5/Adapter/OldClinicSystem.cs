namespace lab5
{
    public class OldClinicSystem
    {
        private readonly double weightInPounds;

        public OldClinicSystem(double weightInPounds)
        {
            this.weightInPounds = weightInPounds;
        }

        public double ReadPounds()
        {
            return weightInPounds;
        }
    }
}