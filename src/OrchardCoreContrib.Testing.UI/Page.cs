using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a page.
/// </summary>
/// <remarks>
/// Creates an instance of <see cref="Page"/>.
/// </remarks>
/// <param name="playwrightPageAccessor">The <see cref="IPlaywrightPageAccessor"/>.</param>
/// <param name="browser">The <see cref="IBrowser"/>.</param>
public class Page(IPlaywrightPageAccessor playwrightPageAccessor, IBrowser browser) : IPage
{
    /// <inheritdoc/>
    public Microsoft.Playwright.IPage InnerPage => playwrightPageAccessor.PlaywrightPage;

    IBrowser IPage.Browser => browser;

    /// <inheritdoc/>
    public string Title { get; set; }

    /// <inheritdoc/>
    public string Content { get; set; }

    /// <inheritdoc/>
    public async Task GoToAsync(string url)
    {
        await InnerPage.GotoAsync(url);

        Title = await InnerPage.TitleAsync();
        Content = await InnerPage.ContentAsync();
    }

    /// <inheritdoc/>
    public IElement FindElement(string selector)
    {
        var locator = InnerPage.Locator(selector);
        var element = new Element(locator, this)
        {
            InnerText = locator.InnerTextAsync().GetAwaiter().GetResult(),
            InnerHtml = locator.InnerHTMLAsync().GetAwaiter().GetResult(),
            Enabled = locator.IsEnabledAsync().GetAwaiter().GetResult(),
            Visible = locator.IsVisibleAsync().GetAwaiter().GetResult()
        };

        return element;
    }

    /// <inheritdoc/>
    public async Task ClickAsync(string selector) => await FindElement(selector).ClickAsync();

    /// <inheritdoc/>
    public async Task ScreenShotAsync(string path, bool fullPage = false)
        => await InnerPage.ScreenshotAsync(new PageScreenshotOptions { Path = path, FullPage = fullPage });
}
