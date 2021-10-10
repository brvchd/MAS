using System;
using MP04.СustomException;

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
        //Business case

        public Person(string firstName, string lastName, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
        }

        public string FirstName { get => firstName; set => firstName = string.IsNullOrWhiteSpace(value) ? value : throw new ModelValidationException("Invalid first name"); }
        public string LastName { get => lastName; set => lastName = string.IsNullOrWhiteSpace(value) ? value : throw new ModelValidationException("Invalid last name"); }
        public string City { get => city; set => city = string.IsNullOrWhiteSpace(value) ? value : throw new ModelValidationException("Invalid city"); }
        public string Country { get => country; set => country = string.IsNullOrWhiteSpace(value) ? value : throw new ModelValidationException("Invalid country"); }
        public Samsung Samsung
        {
            get => samsung; set
            {
                if (apple != null && value != null)
                {
                    RemoveAssosiationFromApple();
                    SetAssosiationWithSamsung(value);
                }
                else if (samsung == null && value != null)
                {
                    SetAssosiationWithSamsung(value);
                }
                else if (value == null && samsung != null)
                {
                    RemoveAssosiationFromSamsung();
                }
            }
        }
        public Apple Apple
        {
            get => apple; set
            {
                if(samsung != null && value != null)
                {
                    RemoveAssosiationFromSamsung();
                    SetAssosiationWithApple(value);
                }
                else if (apple == null && value != null)
                {
                    SetAssosiationWithApple(value);
                }
                else if(value == null && apple != null)
                {
                    RemoveAssosiationFromApple();
                }
                
            }
        }
        public void RemoveAssosiationFromSamsung()
        {
            Samsung tmp = samsung;
            samsung = null;
            tmp.RemovePerson(this);
        }
         public void RemoveAssosiationFromApple()
        {
            Apple tmp = apple;
            apple = null;
            tmp.RemovePerson(this);
        }
        public void SetAssosiationWithApple(Apple apl)
        {
            apple = apl;
            apl.AddPerson(this);
        }
         public void SetAssosiationWithSamsung(Samsung sams)
        {
            samsung = sams;
            sams.AddPerson(this);
        }

    }
}