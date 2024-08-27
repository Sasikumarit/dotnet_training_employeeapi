using EmployeeApi.DTOs;
using MediatR;

namespace EmployeeApi.CQRS.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public EmployeeDto Employee { get; }

        public CreateEmployeeCommand(EmployeeDto employee)
        {
            Employee = employee;
        }
    }
}
