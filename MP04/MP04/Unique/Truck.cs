using System;
using System.Collections.Generic;
using MP04.СustomException;

namespace MP04.Unique
{
    public class Truck
    {
        private string manufacturer;
        private string model;
        private int vinCode;
        private static readonly HashSet<int> vinCodes = new();

        public Truck(int vinCode, string model, string manufacturer)
        {
            VinCode = vinCode;
            Model = model;
            Manufacturer = manufacturer;
            vinCodes.Add(vinCode);
        }

        public int VinCode
        {
            get => vinCode; set
            {
                if(value < 0)
                {
                    throw new ModelValidationException("Wrong VIN number. Cannot be less than 0");
                }
                if(vinCodes.Contains(value))
                {
                    throw new ModelValidationException("VIN number already assigned");
                }
                if(vinCodes.Contains(vinCode) && value != vinCode)
                {
                    vinCodes.Remove(vinCode);
                }
                    vinCode = value;
            }
        }
        public string Model { get => model; set => model = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Wrong model name") : value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Wrong manufacturer name") : value; }
        public static List<int> VinCodes { get => new(vinCodes); }
    }
}