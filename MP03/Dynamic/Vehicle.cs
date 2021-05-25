using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MP03.ModelValidationException;

namespace MP03.Dynamic
{
    public class Vehicle : UsualVehicle, FlyingVehicle, SwimmingVehicle
    {
        private double engineDispalcement;
        private VehicleType typeOfVehicle;
        private EngineType engine;
        private string manufacturer;
        private string model;
        private static List<Vehicle> extent = new();
        private const string EXTENT_FILE = @"Dynamic/extent.json";
        private int waterDisplacement; //optional
        private int wings; //optional
        private double acceleration;

        public Vehicle(string model, string manufacturer, EngineType engine, double engineDispalcement, VehicleType typeOfVehicle, int waterDisplacement = 0, int wings = 0, double acceleration = 0)
        {
            Model = model;
            Manufacturer = manufacturer;
            Engine = engine;
            EngineDispalcement = engineDispalcement;
            TypeOfVehicle = typeOfVehicle;
            if (typeOfVehicle == VehicleType.SWIMMING)
            {
                WaterDisplacement = waterDisplacement;//optional
                Wings = wings;
            }
            if (typeOfVehicle == VehicleType.FLYING)
            {
                Wings = wings;
            }
            if (typeOfVehicle == VehicleType.USUAL)
            {
                Acceleration = acceleration;
            }
            extent.Add(this);
            WriteToFile();
        }

        public string Model { get => model; set => model = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Model cannot be null or empty or wghite space"); }
        public string Manufacturer { get => manufacturer; set => manufacturer = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Manufacturer cannot be null or empty or wghite space"); }
        public EngineType Engine { get => engine; set => engine = !Enum.IsDefined(typeof(EngineType),value) ? value : throw new ModelException("Invalid Engine Type"); }
        public double EngineDispalcement { get => engineDispalcement; set => engineDispalcement = value > 0 ? value : throw new ModelException("Invalid engine displacement"); }
        public VehicleType TypeOfVehicle { get => typeOfVehicle; set => typeOfVehicle = !Enum.IsDefined(typeof(VehicleType),value) ? value : throw new ModelException("Invalid vehicle type"); }
        public int WaterDisplacement { get => waterDisplacement; set => waterDisplacement = value > 1500 ? value : throw new ModelException("Invalid water displacement"); }
        public int Wings { get => wings; set => wings = value >= 1 ? value : throw new ModelException("Invalid amount of wings"); }
        public double Acceleration { get => acceleration; set => acceleration = value > 0 ? value : throw new ModelException("Invalid Acceleration "); }

        public void Drive()
        {
            if (typeOfVehicle == VehicleType.USUAL)
            {
                Console.WriteLine("Vehicle is driving on the ground");
            }
            else
            {
                throw new Exception("Vehicle is not set to usual");
            }
        }

        public void Fly()
        {
            if (typeOfVehicle == VehicleType.FLYING)
            {
                Console.WriteLine("Vehicle is flying in the sky");
            }
            else
            {
                throw new Exception("Vehicle is not set to flying");
            }

        }

        public void Swim()
        {
            if (typeOfVehicle == VehicleType.SWIMMING)
            {
                Console.WriteLine("Vehicle is swimming in the water");
            }
            else
            {
                throw new Exception("Vehicle is not set to swimming");
            }

        }
        public void TransformToFly(int wings)
        {
            if (typeOfVehicle == VehicleType.FLYING)
            {
                throw new Exception("Vehicle is already set to flying.");
            }
            else
            {
                extent.Remove(this);
                waterDisplacement = 0;
                acceleration = 0;
                typeOfVehicle = VehicleType.FLYING;
                Wings = wings;
                extent.Add(this);
                WriteToFile();
            }
        }
        public void TransformToUsual(double acceleration)
        {
            if (typeOfVehicle == VehicleType.USUAL)
            {
                throw new Exception("Vehicle is already set to usual");
            }
            else
            {
                extent.Remove(this);
                waterDisplacement = 0;
                wings = 0;
                typeOfVehicle = VehicleType.USUAL;
                Acceleration = acceleration;
                extent.Add(this);
                WriteToFile();
            }
        }
        public void TransformToSwimming(int waterDisplacement, int wings)
        {
            if (typeOfVehicle == VehicleType.SWIMMING)
            {
                throw new Exception("Vehicle is already set to usual");
            }
            else
            {
                extent.Remove(this);
                acceleration = 0;
                typeOfVehicle = VehicleType.SWIMMING;
                Wings = wings;
                WaterDisplacement = waterDisplacement;
                extent.Add(this);
                WriteToFile();
            }
        }
        public static void WriteToFile()
        {
            if (extent.Count > 0)
            {
                var jsonString = JsonSerializer.Serialize(extent);
                File.WriteAllText(EXTENT_FILE, jsonString);
            }
        }
        public static List<Vehicle> ReadFromFile()
        {
            extent = new List<Vehicle>();
            List<Vehicle> vehicles = new();
            try
            {
                var jsonString = File.ReadAllText(EXTENT_FILE);
                vehicles = JsonSerializer.Deserialize<List<Vehicle>>(jsonString);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return vehicles;
        }
    }
}