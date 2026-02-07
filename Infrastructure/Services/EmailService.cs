using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Application.Abstractions.Services;
using Domain.Email;
using Domain.FileUploads;
using HandlebarsDotNet;
using Infrastructure.Settings;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Infrastructure.Services;

public class EmailService(
    MailSetting mailSetting,
    DataProtectionTokenProviderSetting dataProtectionTokenProviderSetting,
    IFileService fileService,
    ServerSetting serverSetting)
    : IEmailService
{
    
    public async Task SendEmailAsync(EmailModel emailModel, EmailSubject subject,
        HtmlTemplate htmlTemplate)
    {
        MimeMessage message = await BuildMimeMessage(emailModel, subject, htmlTemplate);

        using var client = new SmtpClient();
        await client.ConnectAsync(mailSetting.SmtpServer, mailSetting.Port, SecureSocketOptions.StartTls);
        client.AuthenticationMechanisms.Remove("XOAUTH2");
        await client.AuthenticateAsync(mailSetting.UserName, mailSetting.Password);
        await client.SendAsync(message);
    }

    // public async Task SendEmailForm(EmailModel emailModel, string subject, HtmlTemplate htmlTemplate)
    // {
    //     MimeMessage message = await BuildMimeMessageForm(emailModel, subject, htmlTemplate);
    //
    //     using var client = new SmtpClient();
    //     await client.ConnectAsync(mailSetting.SmtpServer, mailSetting.Port, SecureSocketOptions.StartTls);
    //     client.AuthenticationMechanisms.Remove("XOAUTH2");
    //     await client.AuthenticateAsync(mailSetting.UserName, mailSetting.Password);
    //     await client.SendAsync(message);
    // }

    private async Task<MimeMessage> BuildMimeMessage(EmailModel emailModel, EmailSubject subject,
        HtmlTemplate htmlTemplate)
    {
        var message = new MimeMessage();

        message.From.Add(new MailboxAddress(mailSetting.Name, mailSetting.From));
        message.To.Add(new MailboxAddress(emailModel.ToName, emailModel.ToMail));
        message.Subject = SplitPascalCase(subject.ToString());

        string templateContent = await BuildTemplateAsync(htmlTemplate.ToString(), emailModel);

        var bodyBuilder = new BodyBuilder
        {
            HtmlBody = templateContent
        };
        message.Body = bodyBuilder.ToMessageBody();

        return message;
    }
    
    // private async Task<MimeMessage> BuildMimeMessageForm(EmailModel emailModel, string subject,
    //     HtmlTemplate htmlTemplate)
    // {
    //     var message = new MimeMessage();
    //
    //     message.From.Add(new MailboxAddress(mailSetting.Name, mailSetting.From));
    //     message.To.Add(new MailboxAddress(emailModel.ToName, emailModel.ToMail));
    //     message.Subject = SplitPascalCase(subject.ToString());
    //
    //     string templateContent = await BuildTemplateAsync(htmlTemplate.ToString(), emailModel);
    //
    //     var bodyBuilder = new BodyBuilder
    //     {
    //         HtmlBody = templateContent
    //     };
    //     message.Body = bodyBuilder.ToMessageBody();
    //
    //     return message;
    // }

    private async Task<string> BuildTemplateAsync(string templateName, EmailModel model)
    {
        if (model is ConfirmEmailModel emailModel)
        {
            return await BuildConfirmEmailTemplateAsync(templateName, emailModel);
        }

        if (model is ResetPasswordModel resetPasswordModel)
        {
            return await BuildResetPasswordTemplateAsync(templateName, resetPasswordModel);
        }
        // if (model is EmailModelSender contactFormEmailModel)
        // {
        //     return await BuildFormEmailTemplateAsync(templateName, contactFormEmailModel);
        // }

 

        return string.Empty;
    }

    private async Task<string> BuildConfirmEmailTemplateAsync(string templateName, ConfirmEmailModel model)
    {
        model.RedirectUrl = serverSetting.FrontendBaseUrlForConfirmEmail;
        string templateContent = await GetTemplate(templateName);
        HandlebarsTemplate<object, object>? template = Handlebars.Compile(templateContent);

        string? htmlContent = template(model);

        return htmlContent;
    }
    // private async Task<string> BuildFormEmailTemplateAsync(string templateName, EmailModelSender model)
    // {
    //     string templateContent = await GetTemplate(templateName);
    //     templateContent = templateContent
    //         .Replace("{{NAME}}", model.Name ?? string.Empty)
    //         .Replace("{{EMAIL}}", model.Email ?? string.Empty)
    //         .Replace("{{PHONE}}", model.Phone ?? string.Empty)
    //         .Replace("{{ENTITY_NAME}}", model.EntityName ?? string.Empty)
    //         .Replace("{{REQUEST_TYPE}}", model.RequestType != null ? SplitPascalCase(model.RequestType.ToString()) : string.Empty)
    //         .Replace("{{MESSAGE}}", model.Message ?? string.Empty);
    //     
    //     return templateContent;
    //
    // }
    private async Task<string> BuildResetPasswordTemplateAsync(string templateName, ResetPasswordModel model)
    {
        model.ExpiredInMinutes = dataProtectionTokenProviderSetting.ExpiresIn;
        model.ResetUrl = serverSetting.FrontendBaseUrlForResetPassword;
        string templateContent = await GetTemplate(templateName);
        HandlebarsTemplate<object, object>? template = Handlebars.Compile(templateContent);

        string? htmlContent = template(model);

        return htmlContent;
    }
    

    private async Task<string> GetTemplate(string templateName)
    {
        string? templatePath =
            fileService.GetFilePath(Path.Combine(nameof(FileUploadFor.HtmlTemplates), templateName) + ".html");

        if (!File.Exists(templatePath))
        {
            throw new FileNotFoundException($"Template {templateName} not found.");
        }

        await using FileStream fileStream = new(templatePath, FileMode.Open);
        using StreamReader reader = new(fileStream);
        return await reader.ReadToEndAsync();
    }

    private static string SplitPascalCase(string input)
    {
        return Regex.Replace(input, "(?<!^)([A-Z])", " $1");
    }
}
