using MP02.СustomException;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MP02.WITH_ATTRIBUTE
{
    public class Request
    {
        private Asset assestAssigned;
        private DateTime startDate;
        private string purpose;
        private DateTime validTo;
        private string requestTitle;
        private Employee employeeRequested;
        private static List<Request> extent = new();

        public Request(Asset assestAssigned, string requestTitle, DateTime startDate, string purpose, DateTime validTo, Employee employeeRequested)
        {
            AssestAssigned = assestAssigned;
            RequestTitle = requestTitle;
            StartDate = startDate;
            Purpose = purpose;
            ValidTo = validTo;
            EmployeeRequested = employeeRequested;
            if (RequestAlreadyExists(assestAssigned, employeeRequested))
            {
                throw new Exception("Duplicate association");
            }
            extent.Add(this);
        }

        public Asset AssestAssigned
        {
            get => assestAssigned;
            private set
            {
                assestAssigned = value ?? throw new ModelValidationException("Asset cannot be null");
                value.RequestMade = this;
            }
        }
        public Employee EmployeeRequested
        {
            get => employeeRequested; private set
            {
                employeeRequested = value ?? throw new ModelValidationException("Employee for request cannot be null");
                value.AddRequest(this);
            }
        }

        public string RequestTitle { get => requestTitle; set => requestTitle = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Request title cannot be null or empty"); }
        public DateTime StartDate { get => startDate; set => startDate = !(value < DateTime.Now) ? value : throw new ModelValidationException("Start date cannot be less than current date"); }
        public string Purpose { get => purpose; set => purpose = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Purpose cannot be null or empty"); }
        public DateTime ValidTo { get => validTo; set => validTo = !(value <= StartDate) ? value : throw new ModelValidationException("Validity date cannot be the same as start date"); }

        public void Remove()
        {
            if (assestAssigned != null)
            {
                Asset tmp = assestAssigned;
                assestAssigned = null;
                tmp.RequestMade = null;
            }
            if (employeeRequested != null) 
            {
                Employee tmp = employeeRequested;
                employeeRequested = null;
                tmp.RemoveRequest(this);

            }
        }
        private static bool RequestAlreadyExists(Asset asset, Employee empl)
        {
            var count = extent.Where(e => e.AssestAssigned == asset && e.EmployeeRequested == empl).Count();
            return count > 0;
        }

    }
}
