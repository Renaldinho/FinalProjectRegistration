using Domain;
using FluentValidation;

namespace Application.Validators;

public class StudentValidator: AbstractValidator<Student>
{
    public StudentValidator()
    {
        RuleFor(s => s.Id).GreaterThan(0);
        RuleFor(s => s.ZipCode).GreaterThan(0);
        RuleFor(s => s.Name).NotEmpty();
        RuleFor(s => s.Address).NotEmpty();
        RuleFor(s => s.PostalDistrict).NotEmpty();
    }
}