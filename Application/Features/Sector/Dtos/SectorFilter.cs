
using Domain.Entities.Enums;

namespace Application.Features.Sector.Dtos;

public record SectorFilter(
    string? Name,
    string? Description,
    Ulid? ManagerUserId,
    Ulid? ParentSectorId
    );