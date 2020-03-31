using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        //GET /api/Customers
        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers
                .Include(e=>e.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer,CustomerDto>));
        }

        //GET /api/Customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(e => e.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDto>(customer));
        }

        //POST /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customerDto.Id),customerDto );
        }

        //PUT /api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customerDto, int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(e => e.Id == id);

            if(customerInDb == null)
                return NotFound();
            Mapper.Map(customerDto,customerInDb);

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(e => e.Id == id);

            if (customerInDb == null)
                return NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
