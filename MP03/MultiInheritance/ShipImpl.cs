using System;
using MP03.ModelValidationException;

namespace MP03.MultiInheritance
{
    public class ShipImpl : Vehicle, Ship
    {
        private bool isMilitary;
        private double bodyLength;
        private int waterDisplacement;
        private int fuelAmount;
        private int initialSpeed;

        public ShipImpl(string engineType,
                        int engines,
                        string fuelType,
                        int seatsAvailable,
                        int waterDisplacement,
                        double bodyLength,
                        bool isMilitary, int fuelAmount1, int initialSpeed) : base(engineType, engines, fuelType, seatsAvailable)
        {
            WaterDisplacement = waterDisplacement;
            BodyLength = bodyLength;
            IsMilitary = isMilitary;
            FuelAmount1 = fuelAmount1;
            InitialSpeed = initialSpeed;
        }
        public int WaterDisplacement { get => waterDisplacement; set => waterDisplacement = value > 10000 ? value : throw new ModelException("Invalid water displacement. Cannot be less then 10000tons"); }
        public double BodyLength { get => bodyLength; set => bodyLength = value > 500 ? value : throw new ModelException("Invalid body length"); }
        public bool IsMilitary { get => isMilitary; set => isMilitary = value; }
        public int FuelAmount1 { get => fuelAmount; set => fuelAmount = value > 100000 ? value : throw new ModelException("Invalid fuel amount"); }
        public int InitialSpeed { get => initialSpeed; set => initialSpeed = value > -1 && value < 100 ? value : throw new ModelException("Invalid initial speed"); }

        public void Swim(int speed, int km)
        {
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