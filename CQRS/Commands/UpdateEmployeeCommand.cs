using EmployeeApi.DTOs;
using MediatR;

namespace EmployeeApi.CQRS.Commands
{
    public class UpdateEmployeeCommand : IRequest<bool>
    {
        public string Id { get; }
        public EmployeeDto Employee { get; }

        public UpdateEmployeeCommand(string id, EmployeeDto employee)
        {
            Id = id;
            Employee = employee;
        }
    }
}
