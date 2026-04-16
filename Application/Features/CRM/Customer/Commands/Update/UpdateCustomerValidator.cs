using FluentValidation;

namespace Application.Features.CRM.Customer.Commands.Update;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.Email).EmailAddress().When(x => x.Request.Email != null);
        RuleFor(x => x.Request.Phone).MaximumLength(50).When(x => x.Request.Phone != null);
        RuleFor(x => x.Request.FullName).MaximumLength(200).When(x => x.Request.FullName != null);
    }
}