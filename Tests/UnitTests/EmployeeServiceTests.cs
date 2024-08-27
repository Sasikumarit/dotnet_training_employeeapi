using Xunit;
using Moq;
using AutoMapper;
using EmployeeApi.CQRS.Handlers;
using EmployeeApi.CQRS.Queries;
using EmployeeApi.Repositories;
using EmployeeApi.Models;
using EmployeeApi.DTOs;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeApi.Mappings;

namespace EmployeeApi.Tests.UnitTests
{
    public class EmployeeServiceTests
    {
        private readonly Mock<IEmployeeRepository> _repositoryMock;
        private readonly IMapper _mapper;

        public EmployeeServiceTests()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            _mapper = config.CreateMapper();
        }

        [Fact]
        public async Task GetAllEmployees_ShouldReturnEmployees()
        {
            // Arrange
            var employees = new List<Employee>
            {
                new Employee { Id = "1", FirstName = "Sasi", LastName = "Kumar", Department = "Software Developer" }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(employees);
            var handler = new GetAllEmployeesQueryHandler(_repositoryMock.Object, _mapper);

            // Act
            var result = await handler.Handle(new GetAllEmployeesQuery(), CancellationToken.None);

            // Assert
            Assert.Single(result);
            Assert.Equal("Sasi", result.First().FirstName);
        }
    }
}
