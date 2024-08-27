using EmployeeApi.CQRS.Queries;
using EmployeeApi.DTOs;
using EmployeeApi.Repositories;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.CQRS.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }
    }
}
