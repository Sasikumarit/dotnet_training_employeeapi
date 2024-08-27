using MediatR;

namespace EmployeeApi.CQRS.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public string Id { get; }

        public DeleteEmployeeCommand(string id)
        {
            Id = id;
        }
    }
}
