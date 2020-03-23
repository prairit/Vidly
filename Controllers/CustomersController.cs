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
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            IEnumerable<Customer> listCustomers = _context.Customers;
            return View(listCustomers);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Customer> listCustomers = _context.Customers;
            return View(listCustomers.SingleOrDefault(e => e.Id == id));
        }
    }
}