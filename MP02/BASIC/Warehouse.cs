using MP02.СustomException;
using System;
using System.Collections.Generic;


namespace MP02.BASIC
{
    public class Warehouse
    {
        private string city;
        private int capacity;
        private string nameOfWarehouse;
        private HashSet<RailwayCarriege> carrieges = new();

        public Warehouse(string city, int capacity, string nameOfWarehouse, RailwayCarriege carriege)
        {
            City = city;
            Capacity = capacity;
            NameOfWarehouse = nameOfWarehouse;
            AddCarrieege(carriege);
        }
        public string NameOfWarehouse { get => nameOfWarehouse; set => nameOfWarehouse = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Name cannot be null or empty"); }
        public string City { get => city; set => city = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("City cannot be null or empty"); }
        public int Capacity { get => capacity; set => capacity = !(value < 1000) ? value : throw new ModelValidationException("Capacity cannot be less than 1000 tons"); }
        public HashSet<RailwayCarriege> Carrieges { get => new(carrieges); }
        public void AddCarrieege(RailwayCarriege rc)
        {
            if (rc == null)
                throw new Exception("Carriege cannot be null");
            if (carrieges.Contains(rc))
                return;
            carrieges.Add(rc);
            rc.AssignedWarehouse = this;
        }
        public void RemoveCarriege(RailwayCarriege rc)
        {
            if (carrieges.Count < 1)
                throw new Exception("Cannot remove carriege the last carriege");
            if (!carrieges.Contains(rc))
                return;
            carrieges.Remove(rc);
            rc.AssignedWarehouse = null;
        }

    }
}
