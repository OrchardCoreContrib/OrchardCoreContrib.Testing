namespace OrchardCoreContrib.Testing.Tests;

public class BlogSiteContext : SiteContextBase<OrchardCoreStartup>
{
    public BlogSiteContext() => Options.RecipeName = "Blog";
}
