using Resume.Bussines.Services.implementation;
using Resume.Bussines.Services.Interface;
using Resume.DAL.Repositories.implementation;
using Resume.DAL.Repositories.Interface;

namespace Resume.Web.Configuration
{
    public static class DiContainer 
    {
        #region Methods

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();
        }

        #endregion
    }
}
