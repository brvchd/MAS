using System;

namespace MP02.BASIC
{
    public class ExampleBasic
   {
       public static void Main(string[] args)
       {

           RailwayCarriege rc = new("SA-31311", "WHEAT,BUCKWHEAT", CarriegeType.COMBINED);
           Warehouse wh = new("Warsaw", 5000, "WAW1919", rc);
           RailwayCarriege rc2 = new("SM-1313", "GAS,OIL", CarriegeType.TANK);
           rc2.AssignedWarehouse = wh;
           wh.RemoveCarriege(rc2);
           Warehouse wh2 = new("Kyiv",5000,"KV21",rc);
            Console.WriteLine(wh2.Carrieges);


       }
   }
}
