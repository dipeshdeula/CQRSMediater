using CQRSMediater.Command;
using CQRSMediater.Models;
using CQRSMediater.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CQRSMediater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<List<Employee>> EmployeeList()
        {
            return await _mediator.Send(new GetEmployeeListQuery());
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<Employee> EmployeeById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery { Id = id });

        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new CreateEmployeeCommand(
               employee.Name, employee.Email, employee.Address, employee.Phone
            ));
            return employeeReturn;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<int> UpdateEmployee(Employee employee)
        {
            var employeeReturn = await _mediator.Send(new UpdateEmployeeCommand(
                employee.Id, employee.Name, employee.Email, employee.Address, employee.Phone));
            return employeeReturn;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<int> DeleteEmployee(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(){ Id = id });
        }
    }
}
