using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly_II.Dtos;
using Vidly_II.Models;
using System.Data.Entity;

namespace Vidly_II.Controllers.Api
{
    public class CustomersController : ApiController
    {

        private ApplicationDbContext _dbContext;

        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _dbContext.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        public IHttpActionResult GetCustomer(int Id)
        {
            var customer =  _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri +"/"+ customer.Id), customerDto) ;

        }

        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);


            _dbContext.SaveChanges();

            return Ok(customerDto);

        }


        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.Id == Id);

            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _dbContext.Customers.Remove(customerInDb);
            _dbContext.SaveChanges();

            return Ok();
        }



    }
}
