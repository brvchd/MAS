using System;
using MP03.ModelValidationException;

namespace MP03.MultiInheritance
{
    public class FlyingShip : Plane, Ship
    {
        private int fuelAmount;
        private int initialSpeed;
        private int amountOfPropellers;

        public FlyingShip(string engineType, int engines, string fuelType, int seatsAvailable, int wingLength, int wings, int fuelAmount1, int initialSpeed, int amountOfPropellers) : base(engineType, engines, fuelType, seatsAvailable, wingLength, wings)
        {
            FuelAmount1 = fuelAmount1;
            InitialSpeed = initialSpeed;
            AmountOfPropellers = amountOfPropellers;
        }
        public int FuelAmount1 { get => fuelAmount; set => fuelAmount = value >= 1000 ? value : throw new ModelException("Invalid amount of initial fuel"); }
        public int InitialSpeed { get => initialSpeed; set => initialSpeed = value >= 0 ? value : throw new ModelException("Invalid initial speed"); }
        public int AmountOfPropellers { get => amountOfPropellers; set => amountOfPropellers = value > 0 ? value : throw new ModelException("Invalid amount of Propellers"); }

        public void Swim(int speed, int km)
        {
            Console.WriteLine("Transforming to ship mode");
            var fuelNeeded = speed * km * 10;
            if (speed >= 100)
            {
                throw new Exception("Cannot swim faster than 100kts");
            }
            else if (fuelNeeded > fuelAmount)
            {
                throw new Exception("Insufficient amount of fuel");
            }
            initialSpeed = speed;
            fuelAmount -= fuelNeeded;
        }
    }
}