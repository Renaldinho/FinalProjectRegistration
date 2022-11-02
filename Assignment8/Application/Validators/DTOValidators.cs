using Application.DTOs;
using FluentValidation;

namespace Application.Validators;

public class StudentDTOValidator: AbstractValidator<PostStudentDTO>
{
    public StudentDTOValidator()
    {
        RuleFor(s => s.ZipCode).GreaterThan(0);
        RuleFor(s => s.Name).NotEmpty();
        RuleFor(s => s.Address).NotEmpty();
        RuleFor(s => s.PostalDistrict).NotEmpty();
    }
}