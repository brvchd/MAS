using MP03.ModelValidationException;

namespace MP03.MultiInheritance
{
    public abstract class Vehicle
    {
        private int seatsAvailable;
        private string fuelType;
        private int engines;
        private string engineType;

        public Vehicle(string engineType, int engines, string fuelType, int seatsAvailable)
        {
            EngineType = engineType;
            Engines = engines;
            FuelType = fuelType;
            SeatsAvailable = seatsAvailable;
        }

        public string EngineType { get => engineType; set => engineType = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid engline type"); }
        public int Engines { get => engines; set => engines = value >= 1 ? value : throw new ModelException("Invalid amount of Engines"); }
        public string FuelType { get => fuelType; set => fuelType = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid fuel type"); }
        public int SeatsAvailable { get => seatsAvailable; set => seatsAvailable = value >= 1 ? value : throw new ModelException("Invalid number of seats"); }
    }
}