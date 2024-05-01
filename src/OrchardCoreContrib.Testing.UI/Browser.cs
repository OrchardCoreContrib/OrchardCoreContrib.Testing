using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a browser.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Browser"/>.
/// </remarks>
/// <param name="playwrightBrowserAccessor">The <see cref="IPlaywrightBrowserAccessor"/>.</param>
/// <param name="type">The <see cref="BrowserType"/>.</param>
/// <param name="headless">Whether to run browser in headless mode.</param>
public class Browser(IPlaywrightBrowserAccessor playwrightBrowserAccessor) : IBrowser
{
    /// <inheritdoc/>
    public PlaywrightBrowser InnerBrowser => playwrightBrowserAccessor.PlaywrightBrowser;

    /// <inheritdoc/>
    public BrowserType Type { get; set; }

    /// <inheritdoc/>
    public string Version { get; set; } = playwrightBrowserAccessor.PlaywrightBrowser.Version;

    /// <inheritdoc/>
    public UITestOptions TestOptions { get; set; }

    /// <inheritdoc/>
    public async Task<IPage> OpenPageAsync(string url)
    {
        var playwrightPage = await InnerBrowser.NewPageAsync();

        await playwrightPage.GotoAsync(url);

        var page = new Page(new PlaywrightPageAccessor(playwrightPage), this)
        {
            Title = await playwrightPage.TitleAsync(),
            Content = await playwrightPage.ContentAsync()
        };

        return page;
    }
}
