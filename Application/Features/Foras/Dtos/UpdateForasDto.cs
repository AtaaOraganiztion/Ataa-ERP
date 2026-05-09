using Microsoft.AspNetCore.Http;

namespace Application.Features.Foras.Dtos
{
    public record UpdateForasDto(
        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? FileId,
        Ulid? CreatedByUserId,
        List<IFormFile>? Files,
        List<Ulid>? DeletedFileIds
    );
}
