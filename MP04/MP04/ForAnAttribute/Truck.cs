using System;

namespace MP04.ForAnAttribute
{
    public class Truck
    {

        private static readonly double minLoad = 2000;
        private static readonly double maxLoad = 50000;
        private double currentLoad;
        private int tyresSize = 0;
        private string manufacturer;
        private string model;

        public Truck(string model, string manufacturer, int tyresSize, double currentLoad)
        {
            Model = model;
            Manufacturer = manufacturer;
            TyresSize = tyresSize;
            CurrentLoad = currentLoad;
        }

        public string Model { get => model; set => model = string.IsNullOrWhiteSpace(value) ? throw new Exception("Wrong model name") : value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = string.IsNullOrWhiteSpace(value) ? throw new Exception("Wrong manufacturer") : value; }
        public int TyresSize { get => tyresSize; set => tyresSize = (value > tyresSize) ? value : throw new Exception("Cannot change tyre size") ; }
        public double CurrentLoad { get => currentLoad; set => currentLoad = (value >= minLoad && value <= maxLoad) ? value : throw new Exception("Cannot set the current load"); }



    }
}