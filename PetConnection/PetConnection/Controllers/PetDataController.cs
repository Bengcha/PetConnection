using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetConnection.Controllers
{
    public class PetDataController : Controller
    {
        // GET: PetData
        public ActionResult Index()
        {
            return View();
        }
    }
}