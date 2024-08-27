using EmployeeApi.DTOs;
using FluentValidation;

namespace EmployeeApi.Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.FirstName).NotEmpty().WithMessage("First Name is required.");
            RuleFor(e => e.LastName).NotEmpty().WithMessage("Last Name is required.");
            RuleFor(e => e.Department).NotEmpty().WithMessage("Department is required.");
        }
    }
}
