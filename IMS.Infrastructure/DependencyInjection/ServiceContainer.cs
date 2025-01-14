using IMS.Application.Extension.Identity;
using IMS.Infrastructure.DataAccess;
using IMS.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IMS.Infrastructure.DependencyInjection;

public static class ServiceContainer {

    public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config) {

        services.AddDbContext<AppDbContext>(o => o.UseSqlServer(config.GetConnectionString("Default")), ServiceLifetime.Scoped);

        services.AddAuthentication(options => {

            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        }).AddIdentityCookies();

        services.AddIdentityCore<ApplicationUser>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
        
        services.AddAuthorizationBuilder()
            .AddPolicy("AdministrationPolicy", adp => {
                adp.RequireAuthenticatedUser();
                adp.RequireRole("Admin", "Manager");
            })
            .AddPolicy("UserPolicy", adp => {
                adp.RequireAuthenticatedUser();
                adp.RequireRole("User");
            });

        services.AddCascadingAuthenticationState();
        services.AddScoped<Application.Interface.Identity.IAccount, Account>();
        //services.addMediatR(cfg => cfg.RegisterServiceFromAssemblies(typeof(CreateProductHandler).Assembly));
        //Services.AddScoped<DataAccess.IDbContextFactory<AppDbContext>, DbContextFactory<AppDbContext>>();

        return services;
    }
}
