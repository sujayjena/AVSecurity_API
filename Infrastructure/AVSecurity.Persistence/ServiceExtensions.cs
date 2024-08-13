using AVSecurity.Application.Helpers;
using AVSecurity.Application.Interfaces;
using AVSecurity.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AVSecurity.Persistence
{
    public static class ServiceExtensions
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddScoped<IGenericRepository, GenericRepository>();
            services.AddScoped<IJwtUtilsRepository, JwtUtilsRepository>();
            services.AddScoped<IFileManager, FileManager>();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<ITerritoryRepository, TerritoryRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<ICompanyTypeRepository, CompanyTypeRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IBloodGroupRepository, BloodGroupRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IEmployeeLevelRepository, EmployeeLevelRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IAdminMasterRepository, AdminMasterRepository>();
            services.AddScoped<IAttendanceRegisterRepository, AttendanceRegisterRepository>();
            services.AddScoped<IAccessDoorChecklistRepository, AccessDoorChecklistRepository>();
            services.AddScoped<IBadgesMissingRepository, BadgesMissingRepository>();
            services.AddScoped<ICCTVMonitoringRepository, CCTVMonitoringRepository>();
            services.AddScoped<ICommandCentreRepository, CommandCentreRepository>();
            services.AddScoped<IEmergencyCallLogRepository, EmergencyCallLogRepository>();
            services.AddScoped<IEscortDailyFeedbackRepository, EscortDailyFeedbackRepository>();
            services.AddScoped<IExitEmployeeRepository, ExitEmployeeRepository>();
            services.AddScoped<IFireAlarmChecklistRepository, FireAlarmChecklistRepository>();
            services.AddScoped<IFoodDeliveryRepository, FoodDeliveryRepository>();
            services.AddScoped<IFireExtinguisherRepository, FireExtinguisherRepository>();
            services.AddScoped<IKeyRepository, KeyRepository>();
            services.AddScoped<IHandOverRepository, HandOverRepository>();
            services.AddScoped<ILostAndFoundRepository, LostAndFoundRepository>();
            services.AddScoped<IMasterAccessCardRepository, MasterAccessCardRepository>();
            services.AddScoped<IMaterialInwardNonReturnableRepository, MaterialInwardNonReturnableRepository>();
            services.AddScoped<IMaterialInwardReturnableRepository, MaterialInwardReturnableRepository>();
        }
    }
}
