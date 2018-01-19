using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        public ActionResult Index()
        {
            var customers = GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int customerId)
        {
            var customer = GetCustomers().Where(c => c.Id == customerId).FirstOrDefault();
            return View(customer);
        }

        private List<Customer> GetCustomers()
        {
            var allCustomers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Ognjen Prica" },
                new Customer { Id = 2, Name = "Sasa Prica" }

            };

            return allCustomers;
        }
    }
}