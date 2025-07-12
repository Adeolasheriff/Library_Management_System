using FluentValidation;
using Library_Management_System.Application.DTO;

namespace Library_Management_System.Common.FluentValidations;

public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(b => b.ISBN).NotEmpty().WithMessage("ISBN is required.")
                           .MinimumLength(10).WithMessage("ISBN must be at least 10 characters.");

    }
}
