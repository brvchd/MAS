using System;
using System.Collections.Generic;

namespace MP02.WITH_ATTRIBUTE
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfEmployemnt;
        private string position;
        private string department;
        private HashSet<Request> requestsAssigned = new();

        public Employee(string firstName, string lastName, DateTime dateOfEmployemnt, string position, string department)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfEmployemnt = dateOfEmployemnt;
            Position = position;
            Department = department;
        }
        public HashSet<Request> RequestsAssigned { get => new(requestsAssigned); }
        public void AddRequest(Request r)
        {
            if (r == null)
            {
                throw new Exception("Request cannot be null");
            }
            if (requestsAssigned.Contains(r))
            {
                return;
            }
            if (r.EmployeeRequested != this)
            {
                throw new Exception("Employee is not related with particular request");
            }
            requestsAssigned.Add(r);
        }
        public void RemoveRequest(Request r)
        {
            if (!requestsAssigned.Contains(r))
            {
                return;
            }
            requestsAssigned.Remove(r);
            r.Remove();
        }
        public string FirstName { get => firstName; set => firstName = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("First name cannot be null or empty"); }
        public string LastName { get => lastName; set => lastName = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("Last name cannot be null or empty"); }
        public DateTime DateOfEmployemnt { get => dateOfEmployemnt; set => dateOfEmployemnt = !(value < DateTime.Now) ? value : throw new Exception("Date cannot be less than current date"); }
        public string Position { get => position; set => position = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("Position cannot be null or empty"); }
        public string Department { get => department; set => department = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("Department cannot be null or empty"); }
    }
}
