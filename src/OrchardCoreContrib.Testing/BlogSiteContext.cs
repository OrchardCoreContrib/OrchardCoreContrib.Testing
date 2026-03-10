namespace OrchardCoreContrib.Testing;

public class BlogSiteContext<TEntryPoint> : SiteContextBase<OrchardCoreStartup<TEntryPoint>> where TEntryPoint : class
{
    public BlogSiteContext() => Options.RecipeName = "Blog";
}
