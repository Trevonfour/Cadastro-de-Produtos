using CleanArchMvc.Domain.Account;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMvc.WebUI.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void SeedDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var seedUserRoleInitial =
                scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();

            seedUserRoleInitial.SeedRoles();
            seedUserRoleInitial.SeedUsers();
        }
    }
}
