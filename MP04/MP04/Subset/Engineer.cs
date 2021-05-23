using System;
using MP04.СustomException;

namespace MP04.Subset
{
    public class Engineer
    {
        private string firstName;
        private string lastName;
        private Department leadOfDepartment;
        private Department department;

        public Engineer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FirstName { get => firstName; set => firstName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid first name") : value; }
        public string LastName { get => lastName; set => lastName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid last name") : value; }
        public Department Department
        {
            get => department; set
            {
                if (department == value)
                {
                    return;
                }
                if (department == null && value != null)
                {
                    SetAssosiation(value);
                }
                else if (department != null && value == null)
                {
                    RemoveAssosiation();
                }
                else if (department != null && value != null)
                {
                    RemoveAssosiation();
                    SetAssosiation(value);
                }
            }
        }
        public Department LeadOfDepartment
        {
            get => leadOfDepartment; set
            {
                if (department == null)
                {
                    throw new Exception();
                }
                if (department.DeptName != leadOfDepartment.DeptName)
                {
                    throw new Exception();
                }
                if (leadOfDepartment == null && value != null)
                {
                    SetLeadAssosiation(value);
                }
                else if (leadOfDepartment != null && value == null)
                {
                    RemoveLeadAssosiation();
                }
                else if(leadOfDepartment != null && value != null)
                {
                    RemoveLeadAssosiation();
                    SetLeadAssosiation(value);
                }

            }
        }

        private void RemoveAssosiation()
        {
            Department tmp = Department;
            department = null;
            tmp.RemoveEngineer(this);
        }

        private void SetAssosiation(Department dept)
        {
            department = dept;
            dept.AddEngineer(this);
        }

        private void RemoveLeadAssosiation()
        {
            Department tmp = LeadOfDepartment;
            leadOfDepartment = null;
            tmp.RemoveLeadEngineer(this);
        }

        private void SetLeadAssosiation(Department dept)
        {
            leadOfDepartment = dept;
            dept.AddLeadEngineer(this);
        }

    }
}