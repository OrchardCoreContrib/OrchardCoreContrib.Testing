namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents a base class for page objects.
/// </summary>
public abstract class PageBase
{
    /// <summary>
    /// Gets the underlying <see cref="IPage"/> object.
    /// </summary>
    public IPage Page { get; internal set; }

    /// <summary>
    /// Gets the slug of the page.
    /// </summary>
    public abstract string Slug { get; }

    internal string BaseUrl { get; set; }

    internal async Task<PageBase> GoToAsync()
    {
        await Page.GoToAsync(BaseUrl + Slug);

        return this;
    }
}
