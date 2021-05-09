using System;

namespace MP02.WITH_ATTRIBUTE
{
    public class Asset
    {
        private string iDNumber;
        private string typeOfAsset;
        private Request requestMade;

        public Asset(string iDNumber, string typeOfAsset)
        {
            IDNumber = iDNumber;
            TypeOfAsset = typeOfAsset;
        }

        public Request RequestMade
        {
            get => requestMade; set
            {
                if (requestMade == value)
                {
                    return;
                }
                if (requestMade == null && value != null)
                {
                    if (value.AssestAssigned != this)
                        throw new Exception("Asset is not related to current Request");
                    requestMade = value;
                }
                else if (requestMade != null && value == null)
                {
                    Request tmp = requestMade;
                    requestMade = null;
                    tmp.Remove();

                }
                else if (requestMade != null && value != null)
                {

                    Request tmp = requestMade;
                    requestMade = null;
                    tmp.Remove();

                    if (value.AssestAssigned != this)
                        throw new Exception("Asset is not related to current Request");
                    requestMade = value;
                }
            }
        }
        public string IDNumber { get => iDNumber; set => iDNumber = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("ID Number cannot be null or empty"); }
        public string TypeOfAsset { get => typeOfAsset; set => typeOfAsset = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new Exception("Type of asset cannot be null or empty"); }
    }
}
