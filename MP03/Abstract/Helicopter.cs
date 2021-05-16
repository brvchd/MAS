using System;
using System.Collections.Generic;
using System.Threading;
using MP03.ModelValidationException;

namespace MP03.Abstract
{
    public class Helicopter : ArmoredVehicle
    {
        private string rocketType;
        private int amountOfPropelers;
        private int ammo = 12;
        private bool locked;

        public Helicopter(string model,
                          string manufacturer,
                          int armourThickness,
                          string armourMaterial,
                          string rocketType,
                          int amountOfPropelers) : base(model, manufacturer, armourThickness, armourMaterial)
        {
            RocketType = rocketType;
            AmountOfPropelers = amountOfPropelers;
        }

        public string RocketType { get => rocketType; set => rocketType = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid rocket type"); }
        public int AmountOfPropelers { get => amountOfPropelers; set => amountOfPropelers = value > 1 ? value : throw new ModelException("Invalid amount of propelers"); }

        public override void Attack()
        {
            LockTarget();
            if (ammo > 0)
            {
                Console.WriteLine($"Shoot with {rocketType} confirmed");
                ammo--;
                locked = false;
            }
            else
            {
                Console.WriteLine("Insufficient ammo. Return to base required");
            }

        }
        public void LockTarget()
        {
            if (locked)
            {
                Console.WriteLine("Already locked");
            }
            else
            {
                Console.WriteLine("Locking target...");
                Thread.Sleep(2000);
                Console.WriteLine("Target locked");
                locked = true;
            }

        }
    }
}