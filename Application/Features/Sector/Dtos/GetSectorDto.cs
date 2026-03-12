using Domain.Entities.Enums;

namespace Application.Features.Sector.Dtos;

public record GetSectorDto(
    Ulid? Id = null,
    string? Name = null,
    string? Description = null,
    Ulid? ParentSectorId = null,
    Ulid? ManagerUserId = null,
    int EmployeeCount = 0
);