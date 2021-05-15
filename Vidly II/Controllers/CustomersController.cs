using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly_II.Models;
using Vidly_II.ViewModels;

namespace Vidly_II.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var movie = new Movie() { Title = "Shrek!" };

            var customers = new List<Customer>
            {
                new Customer{Id=1, Name = "Bruce Wayne" },
                new Customer{Id =2, Name = "Clark Kent" }

            };

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var customer = new Customer();
            if (id == 1)
            {
                customer = new Customer() { Id = 1, Name = "Bruce Wayne" };
            }
            else if (id == 2)
            {
                customer = new Customer() { Id = 2, Name = "Clark Kent" };
            }

            return View(customer);
        }
    }
}