using ASPWebAPI.Models;
using ASPWebAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ASPWebAPI.Controllers
{
    public class CustomersController : ApiController
    {
        private CustomersDataAccess _db;

        Customer[] customers = new Customer[]
        {
            new Customer { CustomerId = 1, CustomerName = "Bob Savory" },
        };

        public CustomersController()
        {
            _db = new CustomersDataAccess();
        }

        // GET: api/Customers
        public IEnumerable<Customer> GetAllCustomers()
        {
            return _db.GetCustomers();
        }

        // GET: api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = customers.FirstOrDefault((p) => p.CustomerId == id);
        
            if (customer == null)
            {
                return NotFound();
            }
        
            return Ok(customer);
        }

        // POST: api/customer
        public IHttpActionResult PostCustomer([FromBody]Customer customer)
        {
            try
            {
                _db.InsertCustomer(customer);

                return Created(new Uri(Request.RequestUri + customer.CustomerId.ToString()), customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // POST: api/customer/1
        public IHttpActionResult PutCustomer([FromUri] int customerId, [FromBody]Customer customer)
        {
            try
            {
                _db.UpdateCustomer(customer);

                return Created(new Uri(Request.RequestUri + customer.CustomerId.ToString()), customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        // Delete api/customers/1
        public IHttpActionResult DeleteCustomer(int id)
        {
            try
            {
                _db.DeleteCustomer(id);

                return Created(new Uri(Request.RequestUri + id.ToString()), id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}