using EmployeeApi.CQRS.Commands;
using EmployeeApi.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.CQRS.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _repository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return false;
            }

            employee.FirstName = request.Employee.FirstName;
            employee.LastName = request.Employee.LastName;
            employee.Department = request.Employee.Department;

            await _repository.UpdateAsync(employee);
            return true;
        }
    }
}
