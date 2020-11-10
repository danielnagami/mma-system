using MMASystem.DAL;
using MMASystem.Models;
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

        public User Execute()
        {
            ImageHelper.ValidateImage(_fingerPrint);
            var comparer = new Comparsion();

            var candidate = new Person();
            candidate.Fingerprints.Add(comparer.InitializeFingerprint(_fingerPrint));
            comparer.ExtractMinutiae(candidate);

            var usersRegistered = new Person();
            var mongoUsers = new MongoDAO().Read();
            foreach (var user in mongoUsers)
            {
                if(user.Fingerprint != null)
                {
                    var fingerPrint = comparer.InitializeFingerprint(ImageHelper.ByteArrayToImage(user.Fingerprint));
                    usersRegistered.Fingerprints.Add(fingerPrint);
                    comparer.ExtractMinutiae(usersRegistered);
                    var match = comparer.Match(usersRegistered, candidate);
                    if(match > 100.000f)
                    {
                        return user;
                    }
                    usersRegistered.Fingerprints.Remove(fingerPrint);
                }
            }

            return null;
        }
    }
}