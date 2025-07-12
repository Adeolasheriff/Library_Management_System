using FluentValidation;
using Library_Management_System.Application.DTO;

namespace Library_Management_System.Common.FluentValidations;

public class CreateBookDtoValidator:AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(b => b.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(b => b.Author).NotEmpty().WithMessage("Author is required.");
        RuleFor(b => b.ISBN).NotEmpty().WithMessage("ISBN is required.")
                            .MinimumLength(10).WithMessage("ISBN must be at least 10 characters.");

        
    }
}
