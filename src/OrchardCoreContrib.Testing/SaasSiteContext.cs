namespace OrchardCoreContrib.Testing;

public class SaasSiteContext<TEntryPoint> : SiteContextBase<OrchardCoreStartup<TEntryPoint>> where TEntryPoint : class
{
    public SaasSiteContext() => Options.RecipeName = "Saas";
}
