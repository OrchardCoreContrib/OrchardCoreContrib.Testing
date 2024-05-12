namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents the dashboard page.
/// </summary>
/// <param name="page">The <see cref="IPage"/>.</param>
public class DashboardPage(IPage page) : AdminPage(page)
{
    /// <inheritdoc/>
    public override string Slug => "Admin/";
}
