using MP02.СustomException;

namespace MP02.COMPOSITION
{
    public class SpeakerSet
    {
        private string iD;
        private string modelName;
        private TV installedIn;

        public SpeakerSet(string iD, string modelName, TV installedIn)
        {
            ID = iD;
            ModelName = modelName;
            InstalledIn = installedIn;
        }

        public string ID { get => iD; set => iD = (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationException("ID cannot be null"); }
        public string ModelName { get => modelName; set => modelName = (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? value : throw new ModelValidationException("Model name cannot be null"); }
        public TV InstalledIn
        {
            get => installedIn;
            private set
            {
                if (value == installedIn)
                {
                    return;
                }
                if (installedIn == null && value != null)
                {
                    SetAssociation(value);
                }
                if (installedIn != null && value != null)
                {
                    RemoveAssosiation();
                    SetAssociation(value);
                }

            }
        }
        public void RemoveAssosiation()
        {
            if (installedIn != null)
            {
                TV tmp = installedIn;
                installedIn = null;
                tmp.RemoveSpeakers(this);
            }
        }
        private void SetAssociation(TV tv)
        {
            installedIn = tv;
            tv.AddSpeakers(this);
        }
    }
}
