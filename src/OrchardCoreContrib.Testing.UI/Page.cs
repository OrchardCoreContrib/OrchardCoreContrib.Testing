using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a page.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Page"/>.
/// </remarks>
/// <param name="playwrightPageAccessor">The <see cref="IPlaywrightPageAccessor"/>.</param>
public class Page(IBrowser browser, IPlaywrightPageAccessor playwrightPageAccessor) : IPage
{
    private readonly PageClickOptions _pageClickOptions = browser.Delay == 0
        ? null
        : new() { Delay = browser.Delay };

    /// <inheritdoc/>
    IBrowser IPage.Browser => browser;

    /// <inheritdoc/>
    public Microsoft.Playwright.IPage InnerPage => playwrightPageAccessor.PlaywrightPage;

    /// <inheritdoc/>
    public string Title => InnerPage.TitleAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public string Content => InnerPage.ContentAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public async Task GoToAsync(string url) => await InnerPage.GotoAsync(url);

    /// <inheritdoc/>
    public IElement FindElement(string selector)
    {
        var locator = InnerPage.Locator(selector);

        return new Element(this, locator);
    }

    /// <inheritdoc/>
    public async Task ClickAsync(string selector) => await InnerPage.ClickAsync(selector, _pageClickOptions);

    /// <inheritdoc/>
    public async Task ScreenShotAsync(string path, bool fullPage = false)
        => await InnerPage.ScreenshotAsync(new PageScreenshotOptions { Path = path, FullPage = fullPage });
}
