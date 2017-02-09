using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using PetConnection.Models;
using PetConnection.ViewModel;

namespace PetConnection.Controllers
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
            var customers = _context.User.Include(z => z.City).Include(y => y.States).Include(l => l.ZipCode).ToList();
            return View(customers);
        }
        public ActionResult Edit(int id)
        {
            var customer = _context.User.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                users = customer,
                Cities = _context.City,
                ZipCodes = _context.ZipCode,
                State = _context.States

            };
            return View("CustomerForm", viewModel);
        }


        public ViewResult Details(int id)
        {
            var customer = _context.User.Include(z => z.City).Include(y => y.States)
            .Include(z => z.ZipCode).SingleOrDefault(c => c.Id == id);

            return View(customer);
        }

        public ActionResult New()
        {
            var state = _context.States.ToList();
            var city = _context.City.ToList();
            var zipcode = _context.ZipCode.ToList();
            var viewModel = new CustomerFormViewModel
            {
                users = new User(),

                State = state,
                Cities = city,
                ZipCodes = zipcode

            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    users = user,
                    Cities = _context.City.ToList(),
                    ZipCodes = _context.ZipCode.ToList(),
                    State = _context.States.ToList(),

                };

                return View("CustomerForm", viewModel);
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
                customerInDb.CityId = user.CityId;
                customerInDb.ZipCodeId = user.ZipCodeId;
                customerInDb.StateId = user.StateId;
                customerInDb.EMail = user.EMail;
                customerInDb.AdoptionStatusId = user.AdoptionStatusId;
                //Or use AutoMapper
            }
            _context.SaveChanges();
            return RedirectToAction("Details", user);
        }
        public ActionResult Membership()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}