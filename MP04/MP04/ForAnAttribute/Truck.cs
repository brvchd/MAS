using System.Text.RegularExpressions;
using MP04.СustomException;

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
        private string plateNumber;

        public Truck(string model, string manufacturer, int tyresSize, double currentLoad, string plateNumber)
        {
            Model = model;
            Manufacturer = manufacturer;
            TyresSize = tyresSize;
            CurrentLoad = currentLoad;
            PlateNumber = plateNumber;
        }

        public string Model { get => model; set => model = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid model name") : value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Wrong manufacturer") : value; }
        public int TyresSize { get => tyresSize; set => tyresSize = (value > tyresSize) ? value : throw new ModelValidationException("Cannot change tyre size"); }
        public double CurrentLoad { get => currentLoad; set => currentLoad = (value >= minLoad && value <= maxLoad) ? value : throw new ModelValidationException("Cannot set the current load"); }
        //Custom
        public string PlateNumber
        {
            get => plateNumber; set
            {
                if (!Regex.Match(value, "^[a-zA-Z]+[0-9]+[a-zA-Z]+$").Success)
                {
                    throw new ModelValidationException("Incrorect number plate");
                }
                plateNumber = value;
            }
        }



    }
}