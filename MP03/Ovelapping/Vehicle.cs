using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MP03.ModelValidationException;

namespace MP03.Ovelapping
{
    public class Vehicle
    {
        private string name;
        private HashSet<VehicleType> types;
        private double engineDisplacement;
        private string manufacturer;
        //specific fields
        private int displacementWater; // canswim getset
        private int jetHP; // canfly getset
        private double turboPSI; //canride getset

        public Vehicle(string name, HashSet<VehicleType> types, string manufacturer, double engineDisplacement)
        {
            Name = name;
            Types = types;
            Manufacturer = manufacturer;
            EngineDisplacement = engineDisplacement;
            if (types.Contains(VehicleType.CANFLY))
            {
                jetHP = 1500;
            }
            if(types.Contains(VehicleType.CANRIDE))
            {
                turboPSI = 0.4;
            }
            if(types.Contains(VehicleType.CANSWIM))
            {
                displacementWater = 3000;
            }
        }

        public string Name { get => name; set => name = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Name cannot be null or empty"); }
        public string Manufacturer { get => manufacturer; set => manufacturer = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid manufacturer"); }
        public double EngineDisplacement { get => engineDisplacement; set => engineDisplacement = value > 0 ? value : throw new ModelException("Invalid engine Displacement") ; }
        public HashSet<VehicleType> Types { get => new(types); private set => types = (value == null || value.Count < 1) ? throw new ModelException("Set cannot be null or empty. Put at least one type of vehicle") : value; }

        public void Drive()
        {
            if (types.Contains(VehicleType.CANRIDE))
            {
                Console.WriteLine("Vehicle is now moving on the ground. Interceptor mode is on. Approaching target.");
                turboPSI = 2.8;
                Thread.Sleep(5000);
                Console.WriteLine("Changing to normal mode.Engine overheating");
                turboPSI = 0.4;
            }
            else
            {
                Console.WriteLine("Vehicle cannot move on the ground!");
            }
        }
        public void Fly()
        {
            if (types.Contains(VehicleType.CANFLY))
            {
                Console.WriteLine("Vehicle is now moving in the sky at max power");
                jetHP = 2000;
                Thread.Sleep(5000);
                Console.WriteLine("Changing to normal mode. Cool down your engine");
                jetHP = 1500;
            }
            else
            {
                throw new Exception("Vehicle cannot fly");
            }
        }
        public void Swim()
        {
            if (types.Contains(VehicleType.CANSWIM))
            {
                Console.WriteLine("Vehicle is now moving under the water");
            }
            else
            {
                throw new Exception("Vehicle cannot swim");
            }
        }


    }
}