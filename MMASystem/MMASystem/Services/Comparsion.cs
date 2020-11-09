using SourceAFIS.Simple;
using System;
using System.Drawing;

namespace MMASystem.Services
{
    public class Comparsion
    {
        public void ExtractMinutiae(Person person)
        {
            var afisEngine = new AfisEngine();
            afisEngine.Extract(person);
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
    }
}