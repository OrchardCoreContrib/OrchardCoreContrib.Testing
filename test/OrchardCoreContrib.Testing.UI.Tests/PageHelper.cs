namespace OrchardCoreContrib.Testing.UI.Tests;

public static class PageHelper
{
    public  static string GetFullPath(string pageName)
        => new Uri(Path.Combine(Environment.CurrentDirectory, "Pages", pageName)).AbsoluteUri;
}
