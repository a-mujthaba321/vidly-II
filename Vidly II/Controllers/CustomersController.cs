using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_II.Models;
using Vidly_II.ViewModels;

namespace Vidly_II.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _dbContext;


        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }

        public ActionResult Index()
        {

            var customers = _dbContext.Customers.Include(c=>c.MembershipType).ToList();


            return View(customers);
        }

        public ActionResult Create()
        {
            var membershipTypes = _dbContext.MembershipTypes.ToList();

            var viewModel = new CreateCustomerViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CreateCustomerViewModel
            {
                MembershipTypes = _dbContext.MembershipTypes.ToList(),
                Customer = customer
            };

            return View("Create", viewModel);
        }

        //public ActionResult Index()
        //{
        //    var movie = new Movie() { Title = "Shrek!" };

        //    var customers = new List<Customer>
        //    {
        //        new Customer{Id=1, Name = "Bruce Wayne" },
        //        new Customer{Id =2, Name = "Clark Kent" }

        //    };

        //    var viewModel = new CustomerViewModel
        //    {
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //}

        public ActionResult Details(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
           
            return View(customer);
        }
    }
}