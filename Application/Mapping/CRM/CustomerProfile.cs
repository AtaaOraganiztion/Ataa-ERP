using Application.Features.CRM.Customer.Commands.Add;
using Application.Features.CRM.Customer.Dtos;
using AutoMapper;

namespace Application.Mapping.CRM;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<AddCustomerCommand, Domain.Models.CRM.Customer.Customer>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Ulid.NewUlid()));

        CreateMap<UpdateCustomerDto, Domain.Models.CRM.Customer.Customer>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Domain.Models.CRM.Customer.Customer, GetCustomerDto>()
            .ForCtorParam("id", opt => opt.MapFrom(src => src.Id))
            .ForCtorParam("fullName", opt => opt.MapFrom(src => src.FullName))
            .ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
            .ForCtorParam("phone", opt => opt.MapFrom(src => src.Phone))
            .ForCtorParam("company", opt => opt.MapFrom(src => src.Company))
            .ForCtorParam("address", opt => opt.MapFrom(src => src.Address))
            .ForCtorParam("status", opt => opt.MapFrom(src => src.Status))
            .ForCtorParam("notes", opt => opt.MapFrom(src => src.Notes))
            .ForCtorParam("assignedToUserId", opt => opt.MapFrom(src => src.AssignedToUserId));
    }
}