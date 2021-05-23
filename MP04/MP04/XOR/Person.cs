using System;

namespace MP04.XOR
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string city;
        private string country;
        private Samsung samsung = null;
        private Apple apple = null;

        public Person(string firstName, string lastName, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        public Samsung Samsung
        {
            get => samsung; set
            {
                if (apple != null)
                {
                    throw new Exception();
                }
                if (value != null)
                {
                    samsung = null;
                }
            }
        }
        public Apple Apple
        {
            get => apple; set
            {
                if(samsung != null)
                {
                    throw new Exception();
                }
                if (value != null)
                {
                    apple = value;
                }
            }
        }
    }
}