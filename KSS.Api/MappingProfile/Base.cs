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
            CreateMap<MilitaryServiceStatus, MilitaryServiceStatusDto>().ReverseMap();
            CreateMap<MilitaryServiceStatusTranslation, MilitaryServiceStatusTranslationDto>().ReverseMap();
            CreateMap<InsuranceType, InsuranceTypeDto>().ReverseMap();
            CreateMap<InsuranceTypeTranslation, InsuranceTypeTranslationDto>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusDto>().ReverseMap();
            CreateMap<MaritalStatusTranslation, MaritalStatusTranslationDto>().ReverseMap();
            CreateMap<PersonNationality, PersonNationalityDto>().ReverseMap();
            CreateMap<Religion, ReligionDto>().ReverseMap();
            CreateMap<ReligionTranslation, ReligionTranslationDto>().ReverseMap();
            CreateMap<BirthCertificateSeriesLetter, BirthCertificateSeriesLetterDto>().ReverseMap();
            CreateMap<BirthCertificateSeriesLetterTranslation, BirthCertificateSeriesLetterTranslationDto>().ReverseMap();
            CreateMap<MilitaryServiceLocation, MilitaryServiceLocationDto>().ReverseMap();
            CreateMap<MilitaryServiceLocationTranslation, MilitaryServiceLocationTranslationDto>().ReverseMap();
            CreateMap<PersonStatus, PersonStatusDto>().ReverseMap();
            CreateMap<ContractType, ContractTypeDto>().ReverseMap();
            CreateMap<ContractTypeTranslation, ContractTypeTranslationDto>().ReverseMap();
            CreateMap<BusinessSector, BusinessSectorDto>().ReverseMap();
            CreateMap<BusinessSectorTranslation, BusinessSectorTranslationDto>().ReverseMap();
            CreateMap<BusinessUnit, BusinessUnitDto>().ReverseMap();
            CreateMap<BusinessUnitTranslation, BusinessUnitTranslationDto>().ReverseMap();
            CreateMap<JobPosition, JobPositionDto>().ReverseMap();
            CreateMap<JobPositionTranslation, JobPositionTranslationDto>().ReverseMap();
        }
    }
}