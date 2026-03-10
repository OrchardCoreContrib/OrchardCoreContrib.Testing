using Microsoft.Extensions.DependencyInjection;
using OrchardCore.ContentManagement;
using System.Net;

namespace OrchardCoreContrib.Testing.Tests;

public class OrchardCoreApplicationTests
{
    [Fact]
    public async Task IndexPage_ShouldContainsBlogInItsContent()
    {
        // Arrange
        var context = new BlogSiteContext();
        
        await context.InitializeAsync();

        // Act
        var response = await context.Client.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var content = await response.Content.ReadAsStringAsync();
        Assert.Contains("Blog", content);
    }

    [Fact]
    public async Task Tenant_ShouldAccessServiceFromDIContainer()
    {
        // Arrange
        var context = new BlogSiteContext();

        await context.InitializeAsync();

        // Act & Assert
        await context.UsingTenantScopeAsync(async scope =>
        {
            var siteService = scope.ServiceProvider.GetRequiredService<IContentManager>();

            Assert.NotNull(siteService);
        });
    }
}