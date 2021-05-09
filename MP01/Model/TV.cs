using MP01.Exceptions;
using MP01.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MP01
{
    public class TV
    {
        private long _id;
        public long Id
        {
            get => _id;
            set => _id = (value > 0) ? value : throw new ModelValidationExceptions("Invalid ID. ID cannot be negative");
        }
        private string _modelCode;
        public string ModelCode
        {
            get => _modelCode;
            set => _modelCode = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationExceptions("Invalid model code");
        }
        private int _inches;
        public int Inches
        {
            get => _inches;
            set => _inches = value > 30 ? value : throw new ModelValidationExceptions("Size(inches) is invalid. Value cannot be less than 30.");
        }
        //Optional
        public string VoiceAssistant { get; set; }
        private EnegryConsumption _Consumption;
        public EnegryConsumption Consumption
        {
            get => _Consumption;
            set => _Consumption = (Enum.IsDefined(typeof(EnegryConsumption), value)) ? value : throw new ModelValidationExceptions("Energy concusmption is invalid");
        }
        private string _region;
        public string Region
        {
            get => _region;
            set => _region = !(string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value)) ? value : throw new ModelValidationExceptions("Invalid region");
        }
        private TypeOfModel _typeOfModel;
        public TypeOfModel TypeOfModel
        {
            get => _typeOfModel;
            set => _typeOfModel = (Enum.IsDefined(typeof(TypeOfModel), value)) ? value : throw new ModelValidationExceptions("Type of model is invalid");
        }
        //Complex attribute
        private DateTime _releaseDate;
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set => _releaseDate = !(value == DateTime.MinValue || value == DateTime.MaxValue) ? value : throw new ModelValidationExceptions("Invalid date");
        }
        //Multivalue attribute
        private ISet<String> _features = new HashSet<string>();
        public ISet<String> Features
        {
            get => new HashSet<String>(_features);
            set
            {
                if (!(value == null) || value.Count > 0)
                {
                    foreach (string i in value)
                    {
                        if (string.IsNullOrWhiteSpace(i) || string.IsNullOrEmpty(i))
                            throw new ModelValidationExceptions("Features list is invalid");
                    }
                    _features = new HashSet<string>(value);
                }
            }
        }
        //Complex attribute
        private ModelBoard _modelBoard;
        public ModelBoard ModelBoard
        {
            get => _modelBoard;
            set => _modelBoard = !(value == null) ? value : throw new ModelValidationExceptions("Model board cannot be null");
        }
        public Boolean BuiltInMic { get; set; }
        private int _modelsPlannedToProduce;
        public int ModelsPlannedToProduce
        {
            get => _modelsPlannedToProduce;
            set => _modelsPlannedToProduce = (value > 0) ? value : throw new ModelValidationExceptions("Invalid amount of planned devices to be produced. Value cannot be negative");
        }
        private decimal _averagePrice;
        public decimal AveragePrice
        {
            get => _averagePrice;
            set => _averagePrice = (value > 0) ? value : throw new ModelValidationExceptions("Invalid average price. Value cannot be negative");
        }
        //Class attribute
        private static string manufacturer = "Samsung";
        //GET SET for class attribute
        public string Manufacturer
        {
            get => manufacturer;
            set => manufacturer = !(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationExceptions("Manufacturer cannot be null, empty or white space");
        }
        public static List<TV> extent = new List<TV>();
        public const string EXTENT_FILE = @"C:\Users\dmitr\source\repos\MP01\extent.json";
        //derrived attribute
        public decimal GetEstimatedValue
        {
            get => _averagePrice * _modelsPlannedToProduce;
        }

        //All mandatory attributes
        [JsonConstructor]
        public TV(long id, string modelCode, int inches, string voiceAssistant, EnegryConsumption consumption, string region,
            TypeOfModel typeOfModel, DateTime releaseDate, ISet<string> features, ModelBoard modelBoard, Boolean builtInMic, int modelsPlannedToProduce, decimal averagePrice)
        {
            try
            {
                Id = id;
                ModelCode = modelCode;
                Inches = inches;
                VoiceAssistant = voiceAssistant;
                Consumption = consumption;
                Region = region;
                TypeOfModel = typeOfModel;
                ReleaseDate = releaseDate;
                Features = features;
                ModelBoard = modelBoard;
                BuiltInMic = builtInMic;
                ModelsPlannedToProduce = modelsPlannedToProduce;
                AveragePrice = averagePrice;
                if (!extent.Contains(this)) { extent.Add(this); }

            }
            catch (ModelValidationExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Optional attribute and method overloading
        public TV(long id, string modelCode, int inches, EnegryConsumption consumpition, string region, TypeOfModel typeOfModel, DateTime releaseDate,
            ISet<String> features, ModelBoard board, Boolean builtInMic, int modelsPlannedToProduce, decimal averagePrice)
        {
            try
            {
                Id = id;
                ModelCode = modelCode;
                Inches = inches;
                Consumption = consumpition;
                Region = region;
                TypeOfModel = typeOfModel;
                ReleaseDate = releaseDate;
                Features = features;
                ModelBoard = board;
                BuiltInMic = builtInMic;
                ModelsPlannedToProduce = modelsPlannedToProduce;
                AveragePrice = averagePrice;
                if(!extent.Contains(this)) { extent.Add(this); }
            }
            catch (ModelValidationExceptions ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Methods(just optional)
        public void AddNewFeature(string feature)
        {
            if (string.IsNullOrEmpty(feature) || string.IsNullOrWhiteSpace(feature))
                throw new ModelValidationExceptions("Invalid feature");
            Features.Add(feature);
        }
        public void RemoveFeature(string feature)
        {
            if (string.IsNullOrEmpty(feature) || string.IsNullOrWhiteSpace(feature) || _features.Count < 0 || !_features.Contains(feature))
                throw new ModelValidationExceptions("You cannot remove feature. Possible problems: " +
                    "feature list is empty, you are trying to delete null value," +
                    "provided feature does not exist.");
            Features.Remove(feature);
        }
        //Overriding
        public override string ToString()
        {
            return $"Model code: {ModelCode}, Inches: {Inches}, Release date: {ReleaseDate}, Manufacturer: {Manufacturer}";
        }
        //Class method - sereliazation
        public static void WriteToFile()
        {
            if (extent.Count > 0)
            {
                var jsonString = JsonSerializer.Serialize(extent);
                File.WriteAllText(EXTENT_FILE, jsonString);
            }
        }
        //Class method - deserialization
        public static List<TV> ReadFromFile()
        {
            extent = new List<TV>();
            List<TV> tvs = new List<TV>();
            try
            {
                var jsonString = File.ReadAllText(EXTENT_FILE);
                tvs = JsonSerializer.Deserialize<List<TV>>(jsonString);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tvs;
        }

        public static void ShowModelsWithSpecificInch(int inches)
        {
            if (inches > 30 || extent.Count > 1)
            {
                List<TV> tvs = extent.Where(e => e.Inches == inches).ToList();
                foreach (TV tv in tvs)
                {
                    Console.WriteLine(tv.ToString());
                }
            }
            else
            {
                throw new ModelValidationExceptions("Incorrect parameters");
            }
        }
    }
}
