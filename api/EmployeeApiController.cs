using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleMvcApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleMvcApp.api
{
    [Route("api/[controller]")]
    public class EmployeeApiController : Controller
    {

        private readonly EmployeeContext _db;

        public EmployeeApiController(EmployeeContext db)
        {
            _db = db;
        }
        // GET: api/<controller>
        [HttpGet]
        public IQueryable<Employee> Get()
        {
            return _db.Employees;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        // POST api/<controller>
        [HttpPost("{fullName}")]
        public Employee Post([FromBody]Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();

            return employee;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee updated)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if (employee == null)
                return NotFound();


             employee.Body = updated.Body;
            _db.SaveChanges();

            return Ok();

        } 

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var employee = _db.Employees.FirstOrDefault(x => x.EmployeeId == id);

            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
        }
    }
}
