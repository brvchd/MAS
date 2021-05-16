using System.Collections.Generic;
using MP03.ModelValidationException;

namespace MP03.Abstract
{
    public abstract class ArmoredVehicle
    {
        private string model;
        private string manufacturer;
        private int armourThickness;
        private string armourMaterial;

        protected ArmoredVehicle(string model, string manufacturer, int armourThickness, string armourMaterial)
        {
            Model = model;
            Manufacturer = manufacturer;
            ArmourThickness = armourThickness;
            ArmourMaterial = armourMaterial;
        }

        public string Model { get => model; set => model = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid model"); }
        public string Manufacturer { get => manufacturer; set => manufacturer = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invadil manufacturer"); }
        public int ArmourThickness { get => armourThickness; set => armourThickness = value > 100 ? value : throw new ModelException("Invalid armour thickness"); }
        public string ArmourMaterial { get => armourMaterial; set => armourMaterial = !string.IsNullOrWhiteSpace(value) ? value : throw new ModelException("Invalid material"); }
        public abstract void Attack();
    }
}