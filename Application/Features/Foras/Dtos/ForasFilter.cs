using Domain.Entities.Enums;

namespace Application.Features.Foras.Dtos
{
    public record ForasFilter(
        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? FileId,
        Ulid? CreatedByUserId
        );
}
