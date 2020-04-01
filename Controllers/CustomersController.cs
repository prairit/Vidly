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
                MembershipTypes = membershipTypes,
                Customer = new Customer()
            };
            return View("CustomerForm",model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var model=new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm",model);
            }

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
            return View();
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