using MP01.Model;
using System;
using System.Collections.Generic;

namespace MP01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instances for example
            TV nikem2 = new(1, "GQ55Q80TAUXZG", 55, "S-Voice", EnegryConsumption.D, "CIS", TypeOfModel.PREMIUM, new DateTime(2021, 12, 21), new HashSet<string> { "Bluethooth", "HDR10+" }, new ModelBoard("NKM2", "1502", "AKUC"), true, 100000, 1500);
            TV oscarp = new(2, "GE75Q800T", 75, "Bixby", EnegryConsumption.G, "EU_GER", TypeOfModel.PREMIUM, new DateTime(2021, 12, 10), new HashSet<string> { "Bluethooth", "HDR10+", "8K" }, new ModelBoard("OSCP", "1502", "DEUC"), true, 100000, 10000);
            TV kantsu2p = new(3, "UE43AU8002T", 43, EnegryConsumption.APlusPLus, "EU_BENELUX", TypeOfModel.BASIC, new DateTime(2021, 10, 22), new HashSet<string> { "Bluethooth", "HDR10 Support", "4K" }, new ModelBoard("NKM2", "1502", "AKUC"), true, 100000, 1500);
            //False instances(for checking)
            TV emptystringcheck = new(3, "", 43, EnegryConsumption.APlusPLus, "EU_BENELUX", TypeOfModel.BASIC, new DateTime(2021, 10, 22), new HashSet<string> { "Bluethooth", "HDR10 Support", "4K" }, new ModelBoard("NKM2", "1502", "AKUC"), true, 100000, 1500);
            TV nullcheck = new(3, "UE43AU8002T", 43, EnegryConsumption.APlusPLus, "EU_BENELUX", TypeOfModel.BASIC, new DateTime(2021, 10, 22), new HashSet<string> { "Bluethooth", "HDR10 Support", "4K" }, null, true, 100000, 1500);
            //ToString Check
            TV.extent.ForEach(e => Console.WriteLine(e.ToString()));
            TV.WriteToFile();
            List<TV> tvs = TV.ReadFromFile();
            Console.WriteLine("---------------------Deserialized objects---------------------");
            tvs.ForEach(e => Console.WriteLine(e.ToString()));
            Console.WriteLine("---------------------Class method---------------------");
            TV.ShowModelsWithSpecificInch(55);

        }
    }
}
