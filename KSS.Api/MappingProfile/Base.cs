using AutoMapper;
using KSS.Entity;
using KSS.Dto;

namespace KSS.Api.MappingProfile
{
    public class BaseMappingProfile : Profile
    {
        public BaseMappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Sex, SexDto>().ReverseMap();
            CreateMap<SexTranslation, SexTranslationDto>().ReverseMap();
            CreateMap<PersonTranslation, PersonTranslationDto>().ReverseMap();
            CreateMap<EmailLabel, EmailLabelDto>().ReverseMap();
            CreateMap<EmailLabelTranslation, EmailLabelTranslationDto>().ReverseMap();
            CreateMap<Email, EmailDto>().ReverseMap();
            CreateMap<PhoneLabel, PhoneLabelDto>().ReverseMap();
            CreateMap<PhoneLabelTranslation, PhoneLabelTranslationDto>().ReverseMap();
            CreateMap<Phone, PhoneDto>().ReverseMap();
            CreateMap<AddressLabel, AddressLabelDto>().ReverseMap();
            CreateMap<AddressLabelTranslation, AddressLabelTranslationDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressTranslation, AddressTranslationDto>().ReverseMap();
            CreateMap<JobCategory, JobCategoryDto>().ReverseMap();
            CreateMap<JobCategoryTranslation, JobCategoryTranslationDto>().ReverseMap();
            CreateMap<JobDepartment, JobDepartmentDto>().ReverseMap();
            CreateMap<JobDepartmentTranslation, JobDepartmentTranslationDto>().ReverseMap();
            CreateMap<JobTitle, JobTitleDto>().ReverseMap();
            CreateMap<JobTitleTranslation, JobTitleTranslationDto>().ReverseMap();
            CreateMap<Employment, EmploymentDto>().ReverseMap();
            CreateMap<RelationshipType, RelationshipTypeDto>().ReverseMap();
            CreateMap<RelationshipTypeTranslation, RelationshipTypeTranslationDto>().ReverseMap();
            CreateMap<Relationship, RelationshipDto>().ReverseMap();
        }
    }
}