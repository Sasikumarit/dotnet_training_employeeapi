using EmployeeApi.DTOs;
using MediatR;

namespace EmployeeApi.CQRS.Queries
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeDto>
    {
        public string Id { get; }

        public GetEmployeeByIdQuery(string id)
        {
            Id = id;
        }
    }
}
