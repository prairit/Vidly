using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

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

        public ActionResult New()
        {
            IEnumerable<MembershipType> membershipTypes= _context.MembershipTypes;
            CustomerFormViewModel model = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",model);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if(customer.Id==0)
                _context.Customers.Add(customer);
            else
            {
                _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
            }
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            IEnumerable<Customer> listCustomers = _context.Customers.Include(e =>e.MembershipType);
            return View(listCustomers);
        }

        public ActionResult Details(int id)
        {
            IEnumerable<Customer> listCustomers = _context.Customers.Include(e=>e.MembershipType);
            return View(listCustomers.SingleOrDefault(e => e.Id == id));
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(e => e.Id == id);

            if (customer == null)
                return HttpNotFound();

            var model = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes
            };

            return View("CustomerForm", model);
        }
    }
}