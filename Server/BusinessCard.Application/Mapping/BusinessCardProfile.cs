using AutoMapper;
using BusinessCard.Application.ReadModels.BusinessCard;
using BusinessCard.Application.ReadModels.BusinessCard.Shared;
using BusinessCard.Domain.ValueObjects;


namespace BusinessCard.Application.Mapping
{
    public class BusinessCardProfile : Profile
    {
        public BusinessCardProfile() 
        {
            CreateMap<Domain.BusinessCard, BusinessCardReadModel>();
            CreateMap<PhoneNumber, PhoneNumberReadModel>();
            CreateMap<Address, AddressReadModel>();

        }

    }
}
