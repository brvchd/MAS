using MP04.СustomException;

namespace MP04.XOR
{
    public abstract class Company
    {
        private string city;
        private string country;
        private double capitalisation;

        protected Company(string city, string country, double capitalisation)
        {
            City = city;
            Country = country;
            Capitalisation = capitalisation;
        }

        public string City { get => city; set => city = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid city") : value; }
        public string Country { get => country; set => country = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid country") : value; }
        public double Capitalisation { get => capitalisation; set => capitalisation = value > 0 ? value : throw new ModelValidationException("Cannot be negative"); }
    }
}