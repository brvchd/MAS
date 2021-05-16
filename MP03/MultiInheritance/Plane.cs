using MP03.ModelValidationException;

namespace MP03.MultiInheritance
{
    public class Plane : Vehicle
    {
        private int wings;
        private int wingLength;

        public Plane(string engineType, int engines, string fuelType, int seatsAvailable, int wingLength, int wings) : base(engineType, engines, fuelType, seatsAvailable)
        {
            WingLength = wingLength;
            Wings = wings;
        }

        public int WingLength { get => wingLength; set => wingLength = value > 1000 ? value : throw new ModelException("Invalid wing length"); }
        public int Wings { get => wings; set => wings = value >= 2 ? value : throw new ModelException("Invalid number of wings"); }
    }
}