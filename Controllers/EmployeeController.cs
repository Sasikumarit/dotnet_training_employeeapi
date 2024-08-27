using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Threading.Tasks;
using EmployeeApi.CQRS.Commands;
using EmployeeApi.CQRS.Queries;
using EmployeeApi.DTOs;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var employee = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto employeeDto)
        {
            var command = new CreateEmployeeCommand(employeeDto);
            var employee = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EmployeeDto employeeDto)
        {
            var command = new UpdateEmployeeCommand(id, employeeDto);
            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var command = new DeleteEmployeeCommand(id);
            var result = await _mediator.Send(command);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
