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
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public List<Customer> getList()
        {
            List<Customer> listCustomers=new List<Customer>
            {
                new Customer{Id = 1,Name = "Prairit"},
                new Customer{Id = 2,Name = "Rachit"}
            };
            return listCustomers;
        }
        public ActionResult List()
        {
            return View(getList());
        }

        public ActionResult Details(int id)
        {
            return View(getList().SingleOrDefault(e => e.Id == id));
        }
    }
}