
using Microsoft.IdentityModel.Tokens;
using RIS_Api.DAL;
using RIS_Api.Interfaces;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace RIS_Api.Extensions
{
    public static class ServicesCollection
    {
        public static IServiceCollection InjectServicesCollection(this IServiceCollection services)
        {
            services.AddScoped<IReportDAL, ReportDAL>();
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
