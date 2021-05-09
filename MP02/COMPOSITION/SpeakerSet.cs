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

        public string ID { get => iD; set => iD = value; }
        public string ModelName { get => modelName; set => modelName = value; }
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
