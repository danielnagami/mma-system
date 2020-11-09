using MMASystem.DAL;
using MMASystem.Models;
using MMASystem.Services;
using System.Drawing;
using System.Web;
using System.Web.Mvc;

namespace MMASystem.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("UploadFingerPrint")]
        public string UploadFingerPrint(HttpPostedFileBase file)
        {
            var biometryComparer = new BiometryComparer(Image.FromStream(file.InputStream, true, true));
            biometryComparer.Execute();
            return "test";
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("InsertUser")]
        public ActionResult InsertUser(User user)
        {
            user.Fingerprint = ImageHelper.ConvertUploadToByteArray(user.FingerprintReceiver);

            var db = new MongoDAO();
            db.Create(user);

            return RedirectToAction("Index", "Home");
        }
    }
}