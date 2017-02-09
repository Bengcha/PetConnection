using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PetConnection.Models;

namespace PetConnection.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationDbContext db = new ApplicationDbContext();


        public HomeController()
        {
            _context = new ApplicationDbContext();

        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Blog()
        {
            ViewBag.Message = "Your contact page.";
            var user = _context.PetData.Include(z => z.Type).Include(y => y.Sex).Include(y => y.Color).Include(y => y.Breed).Include(y => y.Age).Include(y => y.Size).Include(y => y.UserId).ToList();
            
            return View(user);
        }


    }
}