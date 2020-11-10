using SourceAFIS.Simple;
using System;
using System.Drawing;

namespace MMASystem.Services
{
    public class Comparsion
    {
        private AfisEngine _afisEngine;
        public Comparsion()
        {
            _afisEngine = new AfisEngine();
        }
        public void ExtractMinutiae(Person person)
        {
            _afisEngine.Extract(person);
        }

        public Fingerprint InitializeFingerprint(Image image)
        {
            try
            {
                return new Fingerprint()
                {
                    AsBitmap = new Bitmap(image)
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot initialize fingerprint object.", ex);
            }
        }

        public float Match(Person probe, Person candidate, float threshold = 100.000f)
        {
            try
            {
                _afisEngine.Threshold = threshold;

                var matchScore = _afisEngine.Verify(probe, candidate);

                return matchScore;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot match.", ex);
            }
        }
    }
}