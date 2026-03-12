using Application.Features.Budget.Commands.Add;
using Application.Features.Budget.Commands.Delete;
using Application.Features.Budget.Dtos;
using AutoMapper;

namespace Application.Mapping.Budget;

public class BudgetProfile : Profile
{
    public BudgetProfile()
    {
        // Add
        CreateMap<AddBudgetCommand, Domain.Models.Finance.Budget.Budget>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()))
            .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        // Update
        CreateMap<UpdateBudgetDto, Domain.Models.Finance.Budget.Budget>()
            .ForMember(dest => dest.EstimatedBudget, opt => opt.MapFrom(src => src.EstimatedBudget ?? default))
            .ForMember(dest => dest.IsConfirmed, opt => opt.MapFrom(src => src.IsConfirmed ?? default))
            .ForMember(dest => dest.Limit, opt => opt.MapFrom(src => src.Limit ?? default))
            .ForMember(dest => dest.TotalBudget, opt => opt.MapFrom(src => src.TotalBudget ?? default))
            .ForMember(dest => dest.AllocatedAmount, opt => opt.MapFrom(src => src.AllocatedAmount ?? default))
            .ForMember(dest => dest.SpentAmount, opt => opt.MapFrom(src => src.SpentAmount ?? default))
            .ForMember(dest => dest.RemainingAmount, opt => opt.MapFrom(src => src.RemainingAmount ?? default))
            .ForMember(dest => dest.BudgetLimit, opt => opt.MapFrom(src => src.BudgetLimit ?? default))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ?? default))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));

        CreateMap<Domain.Models.Finance.Budget.Budget, UpdateBudgetDto>();

        // Get
        CreateMap<Domain.Models.Finance.Budget.Budget, GetBudgetDto>()
            .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.SectorId))
            .ForMember(dest => dest.ConfirmedBy, opt => opt.MapFrom(src => src.ConfirmedBy));

        CreateMap<GetBudgetDto, Domain.Models.Finance.Budget.Budget>();

        // Delete
        CreateMap<DeleteBudgetCommand, Domain.Models.Finance.Budget.Budget>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}