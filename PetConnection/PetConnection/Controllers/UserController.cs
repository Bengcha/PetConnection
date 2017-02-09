using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PetConnection.Models;
using PetConnection.ViewModel;

namespace Trash.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var user = _context.User.Include(z => z.City).Include(y => y.States).Include(l => l.ZipCode).ToList();
            return View(user);
        }
        public ActionResult Edit(int id)
        {
            var user = _context.User.SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();
            var viewModel = new UpdateInformation
            {
                users = user,
                Cities = _context.City,
                ZipCodes = _context.ZipCode,
                State = _context.States,

            };
            return View("updateInformation", viewModel);
        }


        public ViewResult Details(int id)
        {
            var user = _context.User.Include(z => z.City).Include(y => y.States)
            .Include(z => z.ZipCode).SingleOrDefault(c => c.Id == id);

            return View(user);
        }


        public ActionResult New()
        {
            var state = _context.States.ToList();
            var city = _context.City.ToList();
            var zipcode = _context.ZipCode.ToList();
            var viewModel = new UpdateInformation
            {
                users = new User(),

                State = state,
                Cities = city,
                ZipCodes = zipcode,

            };
            return View("updateInformation", viewModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new UpdateInformation
                {
                    users = user,
                    Cities = _context.City.ToList(),
                    ZipCodes = _context.ZipCode.ToList(),
                    State = _context.States.ToList(),

                };

                return View("updateInformation", viewModel);
            }

            if (user.Id == 0)
                _context.User.Add(user);
            else
            {
                var customerInDb = _context.User.Single(c => c.Id == user.Id);

                /*TryUpdateModel(customerInDb); */  //Malicious users can mess-up database
                customerInDb.FirstName = user.FirstName;
                customerInDb.LastName = user.LastName;
                customerInDb.Street = user.Street;
                customerInDb.City = user.City;
                customerInDb.ZipCodeId = user.ZipCodeId;
                customerInDb.StateId = user.StateId;
                customerInDb.EMail = user.EMail;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Profile", user);
        }

    }
}