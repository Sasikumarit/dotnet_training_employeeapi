using EmployeeApi.DTOs;
using MediatR;
using System.Collections.Generic;

namespace EmployeeApi.CQRS.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<EmployeeDto>> { }
}
