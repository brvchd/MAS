using System;
using System.Collections.Generic;
using System.Threading.Channels;
using MP03.ModelValidationException;

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
        private bool isInPresentation;
        private bool isInArt;


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
            if (tvType == TVType.WALLTV)
            {
                isInPresentation = false;
            }
            else
            {
                isInArt = false;
            }
            DefaultBrightness = defaultBrightness;
            Ratio = ratio;
        }

        public int ScreenSize { get => screenSize; set => screenSize = value > 32 ? value : throw new ModelException("Too small screen size"); }
        public string ModelName { get => modelName; set => modelName = string.IsNullOrWhiteSpace(value) ? throw new ModelException("Invalid model name") : value; }
        public string Resolution { get => resolution; set => resolution = string.IsNullOrWhiteSpace(value) ? throw new ModelException("Invalid resolution") : value; }
        public int DefaultBrightness { get => defaultBrightness; set => defaultBrightness = value >= 350 ? value : throw new ModelException("Invalid default brightness"); }
        public string Ratio { get => ratio; set => ratio = string.IsNullOrWhiteSpace(value) ? throw new ModelException("Invalid ratio") : value; }
        private LocalSet Local { get => local; set => local = value; } //should be private
        private TVType TvType { get => tvType; set => tvType = value; } //should be private
        public List<string> Languages { get => languages; set => languages = value; }
        public List<string> ChannelsSet { get => channelsSet; set => channelsSet = value; }

        public List<string> SetAmericanChanells()
        {
            if (local == LocalSet.AMERICA)
            {
                return new List<string>
            {
                "CNN",
                "BBC",
                "NYT"
            };
            }
            else
            {
                throw new Exception("Your TV is not suitable for specific region");
            }
        }

        public List<string> SetAmericanLanguages()
        {
            if (local == LocalSet.AMERICA)
            {
                return new List<string>
            {
                "English",
                "Brazilan",
                "Spanish",
                "French"
            };
            }
            else
            {
                throw new Exception("Your TV is not suitable for specific channels");
            }
        }

        public List<string> SetCISChannels()
        {
            if (local == LocalSet.CIS)
            {
                return new List<string>
            {
                "1+1",
                "Pervii Kanal",
                "RT",
                "5Kanal"
            };
            }
            else
            {
                throw new Exception("Your TV is not suitable for specific channels");
            }

        }

        public List<string> SetCISLanguages()
        {
            if (local == LocalSet.CIS)
            {
                return new List<string>
            {
                "Russian",
                "Ukrainian",
                "Belorussian"
            };
            }
            else
            {
                throw new Exception("Your TV does not support such languages");
            }

        }

        public List<string> SetEuropeanChannels()
        {
            if (local == LocalSet.EUROPEAN)
            {
                return new List<string>
            {
                "TVN",
                "CANAL+",
                "RTL",
                "ARD"
            };
            }
            else
            {
                throw new Exception("Your TV is not suitable for this channels");
            }
        }

        public List<string> SetEuropeanLanguages()
        {
            if (local == LocalSet.EUROPEAN)
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
            else
            {
                throw new Exception("Your TV does not support these languages");
            }
        }

        public void SwitchToArtMode()
        {
            if (tvType != TVType.FASHIONTV)
            {
                throw new Exception("Your TV does not support this feature");
            }
            //checker
            if (DefaultBrightness == 800 && Ratio.Equals("4:3"))
            {
                return;
            }
            if (isInArt)
            {
                Console.WriteLine("You are already in art mode");
                return;
            }
            DefaultBrightness = 800;
            Ratio = "4:9";
            Console.WriteLine("TV switched to Art Mode");
            isInArt = true;
        }

        public void SwitchToPresentationMode()
        {
            if (tvType != TVType.WALLTV)
            {
                throw new Exception("Your TV does not support this feature");
            }
            //checker
            if (DefaultBrightness == 2000 && Ratio.Equals("16:9"))
            {
                return;
            }
            if (isInPresentation)
            {
                Console.WriteLine("You are already in presentation mode");
                return;
            }
            DefaultBrightness = 2000;
            Ratio = "16:9";
            Console.WriteLine("TV switched to Presentation Mode");
            isInPresentation = true;
        }

        public void DisablePresentationMode()
        {
            if (tvType != TVType.WALLTV)
            {
                throw new Exception("Your TV does not support this feature");
            }
            else if (!isInPresentation)
            {
                throw new Exception("You are not in presentation mode");
            }
            DefaultBrightness = 400;
            Ratio = "16:10";
            isInPresentation = false;
        }

        public void DisableArtMode()
        {
            if (tvType != TVType.FASHIONTV)
            {
                throw new Exception("Your TV does not support this feature");
            }
            else if (!isInArt)
            {
                Console.WriteLine("You are not in art mode");
            }
            DefaultBrightness = 1000;
            Ratio = "16:9";
            isInArt = false;
        }
    }
}
