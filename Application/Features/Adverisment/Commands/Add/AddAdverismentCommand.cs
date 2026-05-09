using Application.Abstractions.Messaging;
using Domain.Enums;
using Microsoft.AspNetCore.Http;


namespace Application.Features.Adverisment.Commands.Add
{
    public record AddAdverismentCommand(
        string Title,
        string Description,
        DateTime StartDate,
        DateTime EndDate,
        Ulid? CreatedByUserId,
        string? Url,
        List<IFormFile>? Files
    ) : ICommand<Ulid>;
}
