using LibraryManagementForSchool.Extensions;
using LibraryManagementForSchool.Models;
//using LibraryManagementForSchool.Repositories;
//using LibraryManagementForSchool.Repositories.Interface;
//using LibraryManagementForSchool.Services;
//using LibraryManagementForSchool.Services.Interface;
namespace LibraryManagementForSchool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerExplorer()
                            .InjectDbContext(builder.Configuration)
                            .AddAppConfig(builder.Configuration)
                            .AddIdentityHandlersAndStores()
                            .ConfigureIdentityOptions()
                            .AddIdentityAuth(builder.Configuration);

            var app = builder.Build();

            app.ConfigureSwaggerExplorer()
               .ConfigureCORS(builder.Configuration)
               .AddIdentityAuthMiddlewares();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();

            app.MapGroup("/api")
                .MapIdentityApi<User>();

            //app.MapGroup("/api")
            //    .MapIdentityUserEndpoints()
            //    .MapAccountEndpoints()
            //    .MapAuthorizationDemoEndpoints();
            app.Run();
        }
    }
}

