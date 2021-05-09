using MP02.СustomException;
using System;
using System.Collections.Generic;

namespace MP02.COMPOSITION
{
    public class TV
    {
        private string model;
        private int year;
        private HashSet<SpeakerSet> speakers = new();

        public TV(string model, int year)
        {
            Model = model;
            Year = year;
        }
        public HashSet<SpeakerSet> Speakers { get => new(speakers); }
        public void AddSpeakers(SpeakerSet ss)
        {
            if (ss == null)
            {
                throw new Exception("Set cannot be null");
            }
            if (ss.InstalledIn != this)
            {
                throw new Exception("Not a proper TV");
            }
            speakers.Add(ss);
        }
        public void RemoveSpeakers(SpeakerSet ss)
        {
            if (!speakers.Contains(ss))
            {
                return;
            }
            if (speakers.Count < 2)
            {
                throw new Exception("Cannot remove last set of speakers");
            }
            speakers.Remove(ss);
            ss.RemoveAssosiation();
        }
        public string Model { get => model; set => model = (!string.IsNullOrWhiteSpace(value) || !string.IsNullOrEmpty(value)) ? value : throw new ModelValidationException("Model cannot be null or empty"); }
        public int Year { get => year; set => year = (value < 2018) ? value : throw new ModelValidationException("Year cannot be less than 2018"); }
    }
}
