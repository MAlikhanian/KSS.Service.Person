using KSS.Repository.IRepository;
using KSS.Repository.Repository;
using KSS.Service.IService;
using KSS.Service.Service;
using Microsoft.EntityFrameworkCore;
using KSS.Data.DbContexts;

namespace KSS.Api.ServiceExtention
{
    public static class PersonServiceExtention
    {
        public static IServiceCollection AddPersonServiceExtention(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings")["DefaultConnection"];

            services.AddDbContext<MainDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonAccessChecker, PersonAccessChecker>();
            services.AddScoped<ISexRepository, SexRepository>();
            services.AddScoped<ISexService, SexService>();
            services.AddScoped<ISexTranslationRepository, SexTranslationRepository>();
            services.AddScoped<ISexTranslationService, SexTranslationService>();
            services.AddScoped<ITranslationRepository, TranslationRepository>();
            services.AddScoped<ITranslationService, TranslationService>();
            services.AddScoped<IEmailLabelRepository, EmailLabelRepository>();
            services.AddScoped<IEmailLabelService, EmailLabelService>();
            services.AddScoped<IEmailLabelTranslationRepository, EmailLabelTranslationRepository>();
            services.AddScoped<IEmailLabelTranslationService, EmailLabelTranslationService>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPhoneLabelRepository, PhoneLabelRepository>();
            services.AddScoped<IPhoneLabelService, PhoneLabelService>();
            services.AddScoped<IPhoneLabelTranslationRepository, PhoneLabelTranslationRepository>();
            services.AddScoped<IPhoneLabelTranslationService, PhoneLabelTranslationService>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IAddressLabelRepository, AddressLabelRepository>();
            services.AddScoped<IAddressLabelService, AddressLabelService>();
            services.AddScoped<IAddressLabelTranslationRepository, AddressLabelTranslationRepository>();
            services.AddScoped<IAddressLabelTranslationService, AddressLabelTranslationService>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IAddressTranslationRepository, AddressTranslationRepository>();
            services.AddScoped<IAddressTranslationService, AddressTranslationService>();
            services.AddScoped<IEmploymentRepository, EmploymentRepository>();
            services.AddScoped<IEmploymentService, EmploymentService>();
            services.AddScoped<IRelationshipTypeRepository, RelationshipTypeRepository>();
            services.AddScoped<IRelationshipTypeService, RelationshipTypeService>();
            services.AddScoped<IRelationshipTypeTranslationRepository, RelationshipTypeTranslationRepository>();
            services.AddScoped<IRelationshipTypeTranslationService, RelationshipTypeTranslationService>();
            services.AddScoped<IRelationshipRepository, RelationshipRepository>();
            services.AddScoped<IRelationshipService, RelationshipService>();
            services.AddScoped<IMilitaryServiceStatusRepository, MilitaryServiceStatusRepository>();
            services.AddScoped<IMilitaryServiceStatusService, MilitaryServiceStatusService>();
            services.AddScoped<IMilitaryServiceStatusTranslationRepository, MilitaryServiceStatusTranslationRepository>();
            services.AddScoped<IMilitaryServiceStatusTranslationService, MilitaryServiceStatusTranslationService>();
            services.AddScoped<IInsuranceTypeRepository, InsuranceTypeRepository>();
            services.AddScoped<IInsuranceTypeService, InsuranceTypeService>();
            services.AddScoped<IInsuranceTypeTranslationRepository, InsuranceTypeTranslationRepository>();
            services.AddScoped<IInsuranceTypeTranslationService, InsuranceTypeTranslationService>();
            services.AddScoped<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddScoped<IMaritalStatusService, MaritalStatusService>();
            services.AddScoped<IMaritalStatusTranslationRepository, MaritalStatusTranslationRepository>();
            services.AddScoped<IMaritalStatusTranslationService, MaritalStatusTranslationService>();
            services.AddScoped<INationalityRepository, NationalityRepository>();
            services.AddScoped<INationalityService, NationalityService>();
            services.AddScoped<IReligionRepository, ReligionRepository>();
            services.AddScoped<IReligionService, ReligionService>();
            services.AddScoped<IReligionTranslationRepository, ReligionTranslationRepository>();
            services.AddScoped<IReligionTranslationService, ReligionTranslationService>();
            services.AddScoped<IBirthCertificateSeriesLetterRepository, BirthCertificateSeriesLetterRepository>();
            services.AddScoped<IBirthCertificateSeriesLetterService, BirthCertificateSeriesLetterService>();
            services.AddScoped<IBirthCertificateSeriesLetterTranslationRepository, BirthCertificateSeriesLetterTranslationRepository>();
            services.AddScoped<IBirthCertificateSeriesLetterTranslationService, BirthCertificateSeriesLetterTranslationService>();
            services.AddScoped<IMilitaryServiceLocationRepository, MilitaryServiceLocationRepository>();
            services.AddScoped<IMilitaryServiceLocationService, MilitaryServiceLocationService>();
            services.AddScoped<IMilitaryServiceLocationTranslationRepository, MilitaryServiceLocationTranslationRepository>();
            services.AddScoped<IMilitaryServiceLocationTranslationService, MilitaryServiceLocationTranslationService>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IContractTypeTranslationRepository, ContractTypeTranslationRepository>();
            services.AddScoped<IContractTypeTranslationService, ContractTypeTranslationService>();
            services.AddScoped<IEmploymentActivityFieldRepository, EmploymentActivityFieldRepository>();
            services.AddScoped<IEmploymentActivityFieldService, EmploymentActivityFieldService>();
            services.AddScoped<IEmploymentActivityFieldTranslationRepository, EmploymentActivityFieldTranslationRepository>();
            services.AddScoped<IEmploymentActivityFieldTranslationService, EmploymentActivityFieldTranslationService>();
            services.AddScoped<IEmploymentActivityUnitRepository, EmploymentActivityUnitRepository>();
            services.AddScoped<IEmploymentActivityUnitService, EmploymentActivityUnitService>();
            services.AddScoped<IEmploymentActivityUnitTranslationRepository, EmploymentActivityUnitTranslationRepository>();
            services.AddScoped<IEmploymentActivityUnitTranslationService, EmploymentActivityUnitTranslationService>();
            services.AddScoped<IEmploymentPositionRepository, EmploymentPositionRepository>();
            services.AddScoped<IEmploymentPositionService, EmploymentPositionService>();
            services.AddScoped<IEmploymentPositionTranslationRepository, EmploymentPositionTranslationRepository>();
            services.AddScoped<IEmploymentPositionTranslationService, EmploymentPositionTranslationService>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IDocumentTypeTranslationRepository, DocumentTypeTranslationRepository>();
            services.AddScoped<IDocumentTypeTranslationService, DocumentTypeTranslationService>();
            services.AddScoped<IEducationDocumentTypeRepository, EducationDocumentTypeRepository>();
            services.AddScoped<IEducationDocumentTypeService, EducationDocumentTypeService>();
            services.AddScoped<IEducationDocumentTypeTranslationRepository, EducationDocumentTypeTranslationRepository>();
            services.AddScoped<IEducationDocumentTypeTranslationService, EducationDocumentTypeTranslationService>();
            services.AddScoped<IEmploymentDocumentTypeRepository, EmploymentDocumentTypeRepository>();
            services.AddScoped<IEmploymentDocumentTypeService, EmploymentDocumentTypeService>();
            services.AddScoped<IEmploymentDocumentTypeTranslationRepository, EmploymentDocumentTypeTranslationRepository>();
            services.AddScoped<IEmploymentDocumentTypeTranslationService, EmploymentDocumentTypeTranslationService>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IEmploymentDocumentRepository, EmploymentDocumentRepository>();
            services.AddScoped<IEmploymentDocumentService, EmploymentDocumentService>();
            services.AddScoped<IInstitutionRepository, InstitutionRepository>();
            services.AddScoped<IInstitutionService, InstitutionService>();
            services.AddScoped<IInstitutionTranslationRepository, InstitutionTranslationRepository>();
            services.AddScoped<IInstitutionTranslationService, InstitutionTranslationService>();
            services.AddScoped<IEducationLevelTranslationRepository, EducationLevelTranslationRepository>();
            services.AddScoped<IEducationLevelTranslationService, EducationLevelTranslationService>();
            services.AddScoped<IFieldOfStudyTranslationRepository, FieldOfStudyTranslationRepository>();
            services.AddScoped<IFieldOfStudyTranslationService, FieldOfStudyTranslationService>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IEducationDocumentRepository, EducationDocumentRepository>();
            services.AddScoped<IEducationDocumentService, EducationDocumentService>();
            services.AddScoped<IProfessionalTrainingTypeRepository, ProfessionalTrainingTypeRepository>();
            services.AddScoped<IProfessionalTrainingTypeService, ProfessionalTrainingTypeService>();
            services.AddScoped<IProfessionalTrainingTypeTranslationRepository, ProfessionalTrainingTypeTranslationRepository>();
            services.AddScoped<IProfessionalTrainingTypeTranslationService, ProfessionalTrainingTypeTranslationService>();
            services.AddScoped<IProfessionalTrainingCertificateIssuerRepository, ProfessionalTrainingCertificateIssuerRepository>();
            services.AddScoped<IProfessionalTrainingCertificateIssuerService, ProfessionalTrainingCertificateIssuerService>();
            services.AddScoped<IProfessionalTrainingCertificateIssuerTranslationRepository, ProfessionalTrainingCertificateIssuerTranslationRepository>();
            services.AddScoped<IProfessionalTrainingCertificateIssuerTranslationService, ProfessionalTrainingCertificateIssuerTranslationService>();
            services.AddScoped<IProfessionalTrainingDocumentTypeRepository, ProfessionalTrainingDocumentTypeRepository>();
            services.AddScoped<IProfessionalTrainingDocumentTypeService, ProfessionalTrainingDocumentTypeService>();
            services.AddScoped<IProfessionalTrainingDocumentTypeTranslationRepository, ProfessionalTrainingDocumentTypeTranslationRepository>();
            services.AddScoped<IProfessionalTrainingDocumentTypeTranslationService, ProfessionalTrainingDocumentTypeTranslationService>();
            services.AddScoped<IProfessionalTrainingRepository, ProfessionalTrainingRepository>();
            services.AddScoped<IProfessionalTrainingService, ProfessionalTrainingService>();
            services.AddScoped<IProfessionalTrainingDocumentRepository, ProfessionalTrainingDocumentRepository>();
            services.AddScoped<IProfessionalTrainingDocumentService, ProfessionalTrainingDocumentService>();
            services.AddScoped<IAccessRepository, AccessRepository>();
            services.AddScoped<IAccessService, AccessService>();
            services.AddScoped<IRoleAccessRepository, RoleAccessRepository>();
            services.AddScoped<IRoleAccessService, RoleAccessService>();

            // Required so PersonService and MainDbContext can read JWT claims for the caller.
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
