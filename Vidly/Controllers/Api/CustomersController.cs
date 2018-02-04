using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using WebApplication1.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        /*
         * Ovde je koriscen AutoMapper - pogledati App_Start->MappingProfile.cs
         * Za prenos podataka kod API-ja se koristi DTO(Data Transfer Object) kako
         * ne bismo izlagali model klase(Customer, Movies itd.) krajnjim korisnicima.
         * Ukoliko dodje do promene model klasa, ne moramo nuzno menjati i DTO od tih klasa,
         * pa tako tako dobijamo da neki spoljni servisi koji konzumiraju nas API nece pucati.
         * DTO ne bi trebalo da sadrzi nikakvu logiku, vec samo da sluzi za prenos podataka.
         * U nasem slucaju, svi podaci koje primamo i vracamo se mapiraju na CustomerDTO
         */
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        
        // Get /api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            //Mapiramo Customer objekat na CustomerDTO i vracamo taj CustomerDTO 
            return Ok(Mapper.Map<Customer, CustomerDTO>(customer));
        }

        // POST /api/customers
        //Kod Create, po RESTfull konvenciji koristiti IHttpActionResult kako bi mogli da vratimo 201 Created
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO  customerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.Id = customer.Id;//Id generise baza kada se pozove SaveChanges()

            // Ukoliko je kreiranje uspesno, treba vratiti URI novokreiranog objekta i sam objekat
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        // PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            /*
             *AutoMapper-om update-ujemo property-je od customerInDb na vrednosti iz customerDTO
             * tj. automatski ce odraditi customerInDb.Name = customerDTO.Name itd. redom,
             * za sve namapirane property-je
             */
            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDb);            
            
            _context.SaveChanges();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
