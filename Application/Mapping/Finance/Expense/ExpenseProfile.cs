using Application.Features.Finance.Expense.Commands.Add;
using Application.Features.Finance.Expense.Commands.Delete;
using Application.Features.Finance.Expense.Dtos;
using AutoMapper;

namespace Application.Mapping.Finance.Expense;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        // Add
        CreateMap<AddExpenseCommand, Domain.Models.Finance.Expense.Expense>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()));

        // Update
        CreateMap<UpdateExpenseDto, Domain.Models.Finance.Expense.Expense>();
        CreateMap<Domain.Models.Finance.Expense.Expense, UpdateExpenseDto>();

        // Get
        CreateMap<Domain.Models.Finance.Expense.Expense, GetExpenseDto>()
            .ForMember(dest => dest.SectorId, opt => opt.MapFrom(src => src.SectorId))
            .ForMember(dest => dest.ProjectId, opt => opt.MapFrom(src => src.ProjectId))
            .ForMember(dest => dest.RequestedBy, opt => opt.MapFrom(src => src.RequestedBy))
            .ForMember(dest => dest.ApprovedBy, opt => opt.MapFrom(src => src.ApprovedBy))
            .ForMember(dest => dest.ConfirmedBy, opt => opt.MapFrom(src => src.ConfirmedBy));

        CreateMap<GetExpenseDto, Domain.Models.Finance.Expense.Expense>();

        // Delete
        CreateMap<DeleteExpenseCommand, Domain.Models.Finance.Expense.Expense>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
    }
}