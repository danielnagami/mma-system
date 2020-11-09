using SourceAFIS.Simple;
using System.Drawing;

namespace MMASystem.Services
{
    public class BiometryComparer
    {
        private Image _fingerPrint;
        public BiometryComparer(Image fingerPrint)
        {
            _fingerPrint = fingerPrint;
        }

        public bool Execute()
        {
            ImageHelper.ValidateImage(_fingerPrint);
            var comparer = new Comparsion();

            var tryingUser = new Person();
            comparer.ExtractMinutiae(tryingUser);

            tryingUser.Fingerprints.Add(comparer.InitializeFingerprint(_fingerPrint));



            return true;
        }
    }
}