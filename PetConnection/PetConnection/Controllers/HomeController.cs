using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
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
            //var user = _context.PetData.Include(y => y.Sex).Include(y => y.Color).Include(y => y.Breed).Include(y => y.Age).Include(y => y.Size).Include(y => y.UserId).ToList();
            var x = db.PetData;
            return View(x);
        }
        public ActionResult Shelter()
        {
            return View();
        }
        public ActionResult PetPost()
        {

            return View();
        }
        [HttpPost]
        public ActionResult PetPost(PetData petdata)
        {
            int i = 0;
            PetData used = new PetData();
            used = new PetData { Type = petdata.Type, Sex = petdata.Sex, Color = petdata.Color, Breed = petdata.Breed, Age = petdata.Age, Size = petdata.Size, UserId = i++ };
            
                db.Entry(used).State = EntityState.Modified;
                db.PetData.Add(used);
                db.SaveChanges();

                return RedirectToAction("Index");
           
            return RedirectToAction("Index");
        }


    }
}