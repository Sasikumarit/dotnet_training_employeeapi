using EmployeeApi.CQRS.Commands;
using EmployeeApi.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.CQRS.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _repository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _repository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return false;
            }

            await _repository.DeleteAsync(request.Id);
            return true;
        }
    }
}
