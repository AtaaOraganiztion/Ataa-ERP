using Application.Abstractions.Messaging;
using Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Foras.Commands.Add
{
    public record AddForasCommand(
        string Title,
        string Description,
        string ?Url,
        DateTime StartDate,
        DateTime EndDate,
        Ulid? CreatedByUserId,
        List<IFormFile>? Files
    ) : ICommand<Ulid>;
}
