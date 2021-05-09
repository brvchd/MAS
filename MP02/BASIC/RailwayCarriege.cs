using MP02.СustomException;
using System;

namespace MP02.BASIC
{
    public class RailwayCarriege
    {
        private string identificationName;
        private string allowedСargo;
        private CarriegeType typeOfCarriege;
        private Warehouse assignedWarehouse;

        public RailwayCarriege(string identificationName, string allowedСargo, CarriegeType typeOfCarriege)
        {
            IdentificationName = identificationName;
            AllowedСargo = allowedСargo;
            TypeOfCarriege = typeOfCarriege;
        }
        public Warehouse AssignedWarehouse
        {
            get => assignedWarehouse;
            set
            {
                if (assignedWarehouse == value)
                {
                    return;
                }
                //No warehouse set yet
                if (assignedWarehouse == null && value != null)
                {
                    SetAssociation(value);
                }
                else if (assignedWarehouse != null && value == null)
                {
                    //Remove the warehouse(null as parameter)
                    RemoveAssosiation();
                }
                else if (assignedWarehouse != null && value != null)
                {
                    //Change warehouse
                    RemoveAssosiation();
                    SetAssociation(value);
                }
            }
        }
        public string IdentificationName { get => identificationName; set => identificationName = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Name cannot be null or empty"); }
        public string AllowedСargo { get => allowedСargo; set => allowedСargo = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Allowed cargo cannot be null or empty"); }
        public CarriegeType TypeOfCarriege { get => typeOfCarriege; set => typeOfCarriege = (Enum.IsDefined(typeof(CarriegeType), value)) ? value : throw new ModelValidationException("Should be specific type"); }
        private void RemoveAssosiation()
        {
            Warehouse tmp = AssignedWarehouse;
            assignedWarehouse = null;
            tmp.RemoveCarriege(this);
        }
        private void SetAssociation(Warehouse warehouse)
        {
            assignedWarehouse = warehouse;
            warehouse.AddCarrieege(this);
        }
    }
}
