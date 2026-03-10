namespace OrchardCoreContrib.Testing;

public class AgencySiteContext<TEntryPoint> : SiteContextBase<OrchardCoreStartup<TEntryPoint>> where TEntryPoint : class
{
    public AgencySiteContext() => Options.RecipeName = "Agency";
}
