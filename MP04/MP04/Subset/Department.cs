using System;
using System.Collections.Generic;
using MP04.–°ustomException;

namespace MP04.Subset
{
    public class Department
    {
        private string deptName;
        private readonly HashSet<Engineer> deptMembers = new(); 
        private readonly HashSet<Engineer> leads = new(); 

        public Department(string deptName, Engineer engineer)
        {
            DeptName = deptName;
            deptMembers.Add(engineer);
        }

        public HashSet<Engineer> DeptMembers { get => new(deptMembers); }
        public string DeptName { get => deptName; set => deptName = string.IsNullOrWhiteSpace(value)? throw new ModelValidationException("Invalid dept name") : value; }
        public HashSet<Engineer> Leads { get => new(leads); }

        public void RemoveEngineer(Engineer engineer)
        {
            if (deptMembers.Count < 1)
            {
                throw new Exception();
            }
            if (!deptMembers.Contains(engineer))
            {
                return;
            }
            if(engineer.LeadOfDepartment != null)
            {
                throw new Exception("You cannot remove engineer because he/she is on lead position");
            }
            deptMembers.Remove(engineer);
            engineer.Department = null;
        }

        public void AddEngineer(Engineer engineer)
        {
            if (engineer == null)
            {
                throw new Exception();
            }
            if (deptMembers.Contains(engineer))
            {
                return;
            }
            deptMembers.Add(engineer);
            engineer.Department = this;
        }

        public void AddLeadEngineer(Engineer engineer)
        {
            if (engineer == null)
            {
                throw new Exception();
            }
            if (leads.Contains(engineer))
            {
                return;
            }
            if (deptMembers.Contains(engineer))
            {
                leads.Add(engineer);
                engineer.LeadOfDepartment = this;
            }
        }

        public void RemoveLeadEngineer(Engineer engineer)
        {
            if (leads.Count < 0)
            {
                throw new Exception();
            }
            if (leads.Contains(engineer))
            {
                return;
            }
            leads.Remove(engineer);
            engineer.LeadOfDepartment = null;
        }
    }
}