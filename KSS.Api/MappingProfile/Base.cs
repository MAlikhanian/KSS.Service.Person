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
            CreateMap<Translation, TranslationDto>().ReverseMap();
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
            CreateMap<Nationality, NationalityDto>().ReverseMap();
            CreateMap<Religion, ReligionDto>().ReverseMap();
            CreateMap<ReligionTranslation, ReligionTranslationDto>().ReverseMap();
            CreateMap<BirthCertificateSeriesLetter, BirthCertificateSeriesLetterDto>().ReverseMap();
            CreateMap<BirthCertificateSeriesLetterTranslation, BirthCertificateSeriesLetterTranslationDto>().ReverseMap();
            CreateMap<MilitaryServiceLocation, MilitaryServiceLocationDto>().ReverseMap();
            CreateMap<MilitaryServiceLocationTranslation, MilitaryServiceLocationTranslationDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<ContractType, ContractTypeDto>().ReverseMap();
            CreateMap<ContractTypeTranslation, ContractTypeTranslationDto>().ReverseMap();
            CreateMap<BusinessSector, BusinessSectorDto>().ReverseMap();
            CreateMap<BusinessSectorTranslation, BusinessSectorTranslationDto>().ReverseMap();
            CreateMap<BusinessUnit, BusinessUnitDto>().ReverseMap();
            CreateMap<BusinessUnitTranslation, BusinessUnitTranslationDto>().ReverseMap();
            CreateMap<JobPosition, JobPositionDto>().ReverseMap();
            CreateMap<JobPositionTranslation, JobPositionTranslationDto>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeDto>().ReverseMap();
            CreateMap<DocumentTypeTranslation, DocumentTypeTranslationDto>().ReverseMap();
            CreateMap<EducationDocumentType, EducationDocumentTypeDto>().ReverseMap();
            CreateMap<EducationDocumentTypeTranslation, EducationDocumentTypeTranslationDto>().ReverseMap();
            CreateMap<EmploymentDocumentType, EmploymentDocumentTypeDto>().ReverseMap();
            CreateMap<EmploymentDocumentTypeTranslation, EmploymentDocumentTypeTranslationDto>().ReverseMap();
            CreateMap<Document, DocumentListDto>().ReverseMap();
            CreateMap<DocumentAddDto, Document>().ReverseMap();
            CreateMap<DocumentUpdateDto, Document>().ReverseMap();
            CreateMap<EmploymentDocument, EmploymentDocumentListDto>().ReverseMap();
            CreateMap<EmploymentDocumentAddDto, EmploymentDocument>().ReverseMap();
            CreateMap<Institution, InstitutionDto>().ReverseMap();
            CreateMap<InstitutionTranslation, InstitutionTranslationDto>().ReverseMap();
            CreateMap<EducationLevelTranslation, EducationLevelTranslationDto>().ReverseMap();
            CreateMap<FieldOfStudyTranslation, FieldOfStudyTranslationDto>().ReverseMap();
            CreateMap<Education, EducationListDto>().ReverseMap();
            CreateMap<EducationAddDto, Education>().ReverseMap();
            CreateMap<EducationUpdateDto, Education>().ReverseMap();
            CreateMap<EducationDocument, EducationDocumentListDto>().ReverseMap();
            CreateMap<EducationDocumentAddDto, EducationDocument>().ReverseMap();
            CreateMap<Access, AccessDto>().ReverseMap();
            CreateMap<AccessAddDto, Access>();
            CreateMap<RoleAccess, RoleAccessDto>().ReverseMap();
        }
    }
}