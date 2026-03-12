using Domain.Entities.Enums;

namespace Application.Features.Sector.Dtos;

public record GetSectorDto(
    Ulid? Id = null,
    string? Name = null,
    string? Description = null,
    Ulid? ParentId = null,
    Ulid? ManagerUserId = null
);