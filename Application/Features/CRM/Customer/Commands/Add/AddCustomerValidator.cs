using FluentValidation;

namespace Application.Features.CRM.Customer.Commands.Add;

public class AddCustomerValidator : AbstractValidator<AddCustomerCommand>
{
    public AddCustomerValidator()
    {
        RuleFor(x => x.FullName).MaximumLength(200);
        RuleFor(x => x.Email).EmailAddress().When(x => x.Email != null);
        RuleFor(x => x.Phone).MaximumLength(50).When(x => x.Phone != null);
    }
}