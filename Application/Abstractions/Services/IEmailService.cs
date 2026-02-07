
using Domain.Email;

namespace Application.Abstractions.Services;

public interface IEmailService
{
    Task SendEmailAsync(EmailModel emailModel, EmailSubject subject, HtmlTemplate htmlTemplate);
    // Task SendEmailForm(EmailModel emailModel, string subject, HtmlTemplate htmlTemplate);

}
