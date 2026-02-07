namespace Domain.Email;

public record EmailModel(string ToName, string ToMail, HtmlTemplate htmlTemplate);
