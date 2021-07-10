using DevMeetings.Services.Users.Api.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DevMeetings.Services.Users.Api.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddTransient<IUserService, UserService>();
            
            return services;
        }
    }
}