using System;
using System.Collections.Generic;

namespace MP03.MultiAspect
{
    public class TV : IWallTV, IFashionTV, IAmerican, ICIS, IEuropean
    {
        private int screenSize;
        private string modelName;
        private string resolution;
        private LocalSet local;
        private TVType tvType;
        private List<string> languages;
        private List<string> channelsSet;
        private int defaultBrightness;
        private string ratio;


        public TV(int screenSize, string modelName, string resolution, LocalSet local, TVType tvType, int defaultBrightness, string ratio)
        {
            ScreenSize = screenSize;
            ModelName = modelName;
            Resolution = resolution;
            Local = local;
            TvType = tvType;
            if (local == LocalSet.CIS)
            {
                languages = SetCISLanguages();
                channelsSet = SetCISChannels();
            }
            else if (local == LocalSet.EUROPEAN)
            {
                languages = SetEuropeanLanguages();
                channelsSet = SetEuropeanChannels();
            }
            else if (local == LocalSet.AMERICA)
            {
                languages = SetAmericanLanguages();
                channelsSet = SetAmericanChanells();
            }
            DefaultBrightness = defaultBrightness;
            Ratio = ratio;
        }

        public int ScreenSize { get => screenSize; set => screenSize = value; }
        public string ModelName { get => modelName; set => modelName = value; }
        public string Resolution { get => resolution; set => resolution = value; }
        public int DefaultBrightness { get => defaultBrightness; set => defaultBrightness = value; }
        public string Ratio { get => ratio; set => ratio = value; }
        public LocalSet Local { get => local; set => local = value; } //should be private
        public TVType TvType { get => tvType; set => tvType = value; } //should be private
        public List<string> Languages { get => languages; set => languages = value; }
        public List<string> ChannelsSet { get => channelsSet; set => channelsSet = value; }

        public List<string> SetAmericanChanells()
        {
            return new List<string>
            {
                "CNN",
                "BBC",
                "NYT"
            };
        }

        public List<string> SetAmericanLanguages()
        {
            return new List<string>
            {
                "English",
                "Brazilan",
                "Spanish",
                "French"
            };
        }

        public List<string> SetCISChannels()
        {
            return new List<string>
            {
                "1+1",
                "Pervii Kanal",
                "RT",
                "5Kanal"
            };
        }

        public List<string> SetCISLanguages()
        {
            return new List<string>
            {
                "Russian",
                "Ukrainian",
                "Belorussian"
            };
        }

        public List<string> SetEuropeanChannels()
        {
            return new List<string>
            {
                "TVN",
                "CANAL+",
                "RTL",
                "ARD"
            };
        }

        public List<string> SetEuropeanLanguages()
        {
            return new List<String>
            {
                "German",
                "French",
                "Spanish",
                "Polish",
                "Czech"
            };
        }

        public void SwitchToArtMode()
        {
            //checker
            if (DefaultBrightness == 800 && Ratio.Equals("4:3"))
            {
                return;
            }
            DefaultBrightness = 800;
            Ratio = "4:9";
            Console.WriteLine("TV switched to Art Mode");
        }

        public void SwitchToPresentationMode()
        {
            //checker
            if (DefaultBrightness == 2000 && Ratio.Equals("16:9"))
            {
                return;
            }
            DefaultBrightness = 2000;
            Ratio = "16:9";
            Console.WriteLine("TV switched to Presentation Mode");
        }

        public void DisablePresentationMode()
        {
            DefaultBrightness = 400;
            Ratio = "16:10";
        }

        public void DisableArtMode()
        {
            DefaultBrightness = 1000;
            Ratio = "16:9";
        }
    }
}
