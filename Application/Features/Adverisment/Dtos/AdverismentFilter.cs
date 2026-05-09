
using Domain.Entities.Enums;
namespace Application.Features.Adverisment.Dtos
{
    public record AdverismentFilter(
        string? Title,
        DateTime? startdate,
        DateTime? enddate,
        string? Description,
        Ulid? FileId,
        Ulid? CreatedByUserId
        );
}
