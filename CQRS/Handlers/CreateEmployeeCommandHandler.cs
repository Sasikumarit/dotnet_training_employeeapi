using EmployeeApi.CQRS.Commands;
using EmployeeApi.DTOs;
using EmployeeApi.Models;
using EmployeeApi.Repositories;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeApi.CQRS.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = _mapper.Map<Employee>(request.Employee);
            await _repository.AddAsync(employee);
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
