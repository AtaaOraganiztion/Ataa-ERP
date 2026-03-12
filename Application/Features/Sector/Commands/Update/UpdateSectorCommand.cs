using Application.Abstractions.Messaging;
using Application.Features.Employee.Dtos;
using Application.Features.Sector.Dtos;

namespace Application.Features.Sector.Commands.Update;

public record UpdateSectorCommand(Ulid Id, UpdateSectorDto? SectorDto) : ICommand<Ulid>;
