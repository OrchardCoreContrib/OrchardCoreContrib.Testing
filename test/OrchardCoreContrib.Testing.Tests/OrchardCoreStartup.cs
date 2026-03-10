using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCoreContrib.Testing.Security;

namespace OrchardCoreContrib.Testing.Tests;

public class OrchardCoreStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddOrchardCms(builder => builder
            .AddSetupFeatures("OrchardCore.Tenants")
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddScoped<IAuthorizationHandler, PermissionContextAuthorizationHandler>(sp =>
                    new PermissionContextAuthorizationHandler(sp.GetRequiredService<IHttpContextAccessor>(), SiteContextOptions.PermissionsContexts));
            })
            .Configure(appBuilder => appBuilder.UseAuthorization()));

        services.AddSingleton<IModuleNamesProvider>(new ModuleNamesProvider(typeof(Web.Program).Assembly));
    }

    public void Configure(IApplicationBuilder app) => app.UseOrchardCore();
}