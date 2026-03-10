using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCoreContrib.Testing.Security;

namespace OrchardCoreContrib.Testing;

public class OrchardCoreStartup<TEntryPoint> : StartupBase where TEntryPoint : class
{
    public override void ConfigureServices(IServiceCollection services)
    {
        services.AddOrchardCms(builder => builder
            .AddSetupFeatures("OrchardCore.Tenants")
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddScoped<IAuthorizationHandler, PermissionContextAuthorizationHandler>(sp =>
                    new PermissionContextAuthorizationHandler(sp.GetRequiredService<IHttpContextAccessor>(), SiteContextOptions.PermissionsContexts));
            })
            .Configure(appBuilder => appBuilder.UseAuthorization()));

        services.AddSingleton<IModuleNamesProvider>(new ModuleNamesProvider(typeof(TEntryPoint).Assembly));
    }

    public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        => app.UseOrchardCore();
}