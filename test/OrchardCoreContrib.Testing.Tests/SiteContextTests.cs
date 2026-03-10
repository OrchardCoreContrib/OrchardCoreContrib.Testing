namespace OrchardCoreContrib.Testing.Tests;

public class SiteContextTests
{
    [Fact]
    public async Task Site_ShouldBeSameForAllSites()
    {
        // Arrange & Act
        var _ = new BlogSiteContext();
        var site1 = BlogSiteContext.Site;

        var __ = new BlogSiteContext();
        var site2 = BlogSiteContext.Site;

        // Assert
        Assert.Same(site1, site2);
    }

    [Fact]
    public async Task ShellHost_ShouldBeSameForAllSites()
    {
        // Arrange & Act
        var _ = new BlogSiteContext();
        var shellHost1 = BlogSiteContext.ShellHost;

        var __ = new BlogSiteContext();
        var shellHost2 = BlogSiteContext.ShellHost;

        // Assert
        Assert.Same(shellHost1, shellHost2);
    }

    [Fact]
    public async Task ShellSettingsManager_ShouldBeSameForAllSites()
    {
        // Arrange & Act
        var _ = new BlogSiteContext();
        var shellSettingsManager1 = BlogSiteContext.ShellSettingsManager;

        var __ = new BlogSiteContext();
        var shellSettingsManager2 = BlogSiteContext.ShellSettingsManager;

        // Assert
        Assert.Same(shellSettingsManager1, shellSettingsManager2);
    }

    [Fact]
    public async Task HttpContextAccessor_ShouldBeSameForAllSites()
    {
        // Arrange & Act
        var _ = new BlogSiteContext();
        var httpContextAccessor1 = BlogSiteContext.HttpContextAccessor;

        var __ = new BlogSiteContext();
        var httpContextAccessor2 = BlogSiteContext.HttpContextAccessor;

        // Assert
        Assert.Same(httpContextAccessor1, httpContextAccessor2);
    }

    [Fact]
    public async Task Options_ShouldBeSetOnConstructor()
    {
        // Arrange
        BlogSiteContext siteContext;

        // Act
        siteContext = new BlogSiteContext();

        // Assert
        Assert.NotNull(siteContext.Options);
    }

    [Fact]
    public async Task Client_ShouldBeSetAfterCallingInitializeAsync()
    {
        // Arrange
        var siteContext = new BlogSiteContext();

        Assert.Null(siteContext.Client);

        // Act
        await siteContext.InitializeAsync();

        // Assert
        Assert.NotNull(siteContext.Client);
    }

    [Fact]
    public async Task TenantName_ShouldBeSetAfterCallingInitializeAsync()
    {
        // Arrange
        var siteContext = new BlogSiteContext();

        Assert.Null(siteContext.TenantName);

        // Act
        await siteContext.InitializeAsync();

        // Assert
        Assert.NotNull(siteContext.TenantName);
    }

    [Fact]
    public async Task CallingInitializeAsyncMultipleTimes_ShouldChangeTenantName()
    {
        // Arrange
        var siteContext = new BlogSiteContext();

        // Act
        await siteContext.InitializeAsync();

        var tenant1 = siteContext.TenantName;

        await siteContext.InitializeAsync();

        var tenant2 = siteContext.TenantName;

        // Assert
        Assert.NotEqual(tenant1, tenant2);
    }
}
