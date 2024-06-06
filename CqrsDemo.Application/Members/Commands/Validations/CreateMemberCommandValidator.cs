using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CqrsDemo.Application.Members.Commands.Validations;
public class CreateMemberCommandValidator : AbstractValidator<CreateMemberCommand>
{
    public CreateMemberCommandValidator()
    {
        RuleFor(c => c.FirstName)
          .NotEmpty().WithMessage("Please ensure you have entered the FirstName")
          .Length(4, 100).WithMessage("The FirstName must have between 4 and 150 characters");

        RuleFor(c => c.LastName)
           .NotEmpty().WithMessage("Please ensure you have entered the LastName")
           .Length(4, 100).WithMessage("The LastName must have between 4 and 150 characters");

        RuleFor(c => c.Email)
           .NotEmpty()
           .EmailAddress();

        RuleFor(x => x.IsActive).NotNull();
    }
}