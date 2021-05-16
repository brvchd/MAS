using System;
using System.Collections.Generic;
using System.Threading;
using MP03.ModelValidationException;

namespace MP03.Abstract
{
    public class Tank : ArmoredVehicle
    {
        private int barellSize;
        private int trackLengh;
        private int seatAmount;
        private bool autoLoad;
        private bool reload = false;
        private int availableWeapons = 24;

        public Tank(string model,
                    string manufacturer,
                    int armourThickness,
                    string armourMaterial,
                    int barellSize,
                    int trackLengh,
                    int seatAmount,
                    bool autoLoad) : base(model, manufacturer, armourThickness, armourMaterial)
        {
            BarellSize = barellSize;
            TrackLengh = trackLengh;
            SeatAmount = seatAmount;
            AutoLoad = autoLoad;
        }

        public int BarellSize { get => barellSize; set => barellSize = value >= 100 ? value : throw new ModelException("Invalid barell size"); }
        public int TrackLengh { get => trackLengh; set => trackLengh = value >= 10 ? value : throw new ModelException("Invalid track length"); }
        public int SeatAmount { get => seatAmount; set => seatAmount = value >= 2 ? value : throw new ModelException("Invalid seat amount") ; }
        public bool AutoLoad { get => autoLoad; set => autoLoad = value; }

        public override void Attack()
        {
            if (reload)
            {
                Console.WriteLine("Cannot shoot the target");
            }
            else
            {
                Console.WriteLine($"Enemy hit confirmed with {barellSize}mm barrel");
                Reload();
            }

        }
        public void Reload()
        {
            if (availableWeapons < 0)
            {
                Console.WriteLine("No ammo left. We cannot reload");
                reload = true;
            }
            else
            {
                reload = true;
                Console.WriteLine("Reloading the turret...");
                Thread.Sleep(5000);
                Console.WriteLine("Turret reloaded. Ready to fire");
                availableWeapons--;
                reload = false;

            }

        }
    }
}