using MP02.СustomException;
using System;

namespace MP02.QUALIFIED
{
    public class Employee
    {
        private string firstName;
        private string lastName;
        private int iD;
        private Department depart;

        public Employee(string firstName, string lastName, int iD, Department dept)
        {
            FirstName = firstName;
            LastName = lastName;
            ID = iD;
            Department = dept;
        }

        public string FirstName { get => firstName; set => firstName = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Name cannot be null or empty"); }
        public string LastName { get => lastName; set => lastName = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Last name cannot be null or empty"); }
        public int ID { get => iD; set => iD = !(value < 1) ? value : throw new ModelValidationException("ID cannot be negative"); }
        public Department Department
        {
            get => depart;
            set
            {
                if (depart == value)
                {
                    return;
                }
                if (depart == null && value != null)
                {
                    SetAssociation(value);
                }
                if (depart != null && value == null)
                {
                    RemoveAssosiation();
                }
                if (depart != null && value != null)
                {
                    RemoveAssosiation();
                    SetAssociation(value);
                }
            }
        }
        private void RemoveAssosiation()
        {
            Department tmp = depart;
            depart = null;
            tmp.RemoveEmployee(this);
        }
        private void SetAssociation(Department dept)
        {
            depart = dept;
            dept.AddEmployee(this);
        }
    }
}
