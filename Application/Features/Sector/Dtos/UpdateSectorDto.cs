
using Domain.Entities.Enums;

namespace Application.Features.Sector.Dtos;

public record UpdateSectorDto(
    string? Name,
    string? Description,
    Ulid? ParentId,
    Ulid? ManagerUserId
    );