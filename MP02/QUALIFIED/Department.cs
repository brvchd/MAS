using System;
using System.Collections.Generic;

namespace MP02.QUALIFIED
{
    public class Department
    {
        private Dictionary<int, Employee> employees = new();
        private string name;

        public Department(string name)
        {
            Name = name;
        }

        public string Name { get => name; set => name = (!string.IsNullOrEmpty(value) || !string.IsNullOrWhiteSpace(value)) ? value : throw new Exception("Name cannot be null or empty"); }
        public Dictionary<int, Employee> Employees { get => new(employees); }
        public Employee FindEmpoyee(int id)
        {
            return employees[id];
        }
        public void AddEmployee(Employee e)
        {
            if (e == null)
            {
                throw new Exception("Employee cannot be null");
            }
            if (employees.ContainsKey(e.ID))
            {
                return;
            }
            employees.Add(e.ID, e);
            e.Department = this;
        }

        public void RemoveEmployee(Employee e)
        {
            if (e == null)
            {
                throw new Exception("Employee cannot be null");
            }
            if (!employees.ContainsKey(e.ID))
            {
                return;
            }
            employees.Remove(e.ID);
            e.Department = null;
        }

    }
}
