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
            services.AddScoped<ISexRepository, SexRepository>();
            services.AddScoped<ISexService, SexService>();
            services.AddScoped<ISexTranslationRepository, SexTranslationRepository>();
            services.AddScoped<ISexTranslationService, SexTranslationService>();
            services.AddScoped<IPersonTranslationRepository, PersonTranslationRepository>();
            services.AddScoped<IPersonTranslationService, PersonTranslationService>();
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
            services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();
            services.AddScoped<IJobCategoryService, JobCategoryService>();
            services.AddScoped<IJobCategoryTranslationRepository, JobCategoryTranslationRepository>();
            services.AddScoped<IJobCategoryTranslationService, JobCategoryTranslationService>();
            services.AddScoped<IJobDepartmentRepository, JobDepartmentRepository>();
            services.AddScoped<IJobDepartmentService, JobDepartmentService>();
            services.AddScoped<IJobDepartmentTranslationRepository, JobDepartmentTranslationRepository>();
            services.AddScoped<IJobDepartmentTranslationService, JobDepartmentTranslationService>();
            services.AddScoped<IJobTitleRepository, JobTitleRepository>();
            services.AddScoped<IJobTitleService, JobTitleService>();
            services.AddScoped<IJobTitleTranslationRepository, JobTitleTranslationRepository>();
            services.AddScoped<IJobTitleTranslationService, JobTitleTranslationService>();
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
            services.AddScoped<IPersonNationalityRepository, PersonNationalityRepository>();
            services.AddScoped<IPersonNationalityService, PersonNationalityService>();
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
            services.AddScoped<IPersonStatusRepository, PersonStatusRepository>();
            services.AddScoped<IPersonStatusService, PersonStatusService>();
            services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
            services.AddScoped<IContractTypeService, ContractTypeService>();
            services.AddScoped<IContractTypeTranslationRepository, ContractTypeTranslationRepository>();
            services.AddScoped<IContractTypeTranslationService, ContractTypeTranslationService>();

            return services;
        }
    }
}
