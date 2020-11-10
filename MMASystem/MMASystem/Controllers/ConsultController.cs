using MMASystem.DAL;
using MMASystem.Models;
using System;
using System.Web.Mvc;

namespace MMASystem.Controllers
{
    public class ConsultController : Controller
    {
        // GET: Consult
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("Create")]
        public bool Create(Properties property)
        {
            try
            {
                var data = new ConsultDAO();
                data.Create(property);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ActionResult Basic()
        {
            var data = new ConsultDAO().Read();
            return View(data);
        }

        public ActionResult Advanced()
        {
            var data = new ConsultDAO().Read();
            return View(data);
        }
    }
}