using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents an element with a <see cref="IPage"/>.
/// </summary>
/// <remarks>The <see cref="Element"/>.</remarks>
/// <param name="locator">The <see cref="ILocator"/>.</param>
public class Element(IPage page, ILocator locator) : IElement
{
    private readonly LocatorClickOptions _locatorClickOptions = page.Browser.Delay == 0
        ? null
        : new() { Delay = page.Browser.Delay };
    private readonly LocatorPressSequentiallyOptions _locatorPressSequentiallyOptions = page.Browser.Delay == 0
        ? null
        : new() { Delay = page.Browser.Delay };

    IPage IElement.Page => page;

    /// <inheritdoc/>
    public string InnerText { get; set; }

    /// <inheritdoc/>
    public string InnerHtml { get; set; }

    /// <inheritdoc/>
    public bool Enabled { get; set; }

    /// <inheritdoc/>
    public bool Visible { get; set; }

    /// <inheritdoc/>
    public async Task ClickAsync() => await locator.ClickAsync(_locatorClickOptions);

    /// <inheritdoc/>
    public async Task TypeAsync(string text)
    {
        await locator.FillAsync(text);

        InnerText = await locator.InnerTextAsync();
        InnerHtml = await locator.InnerHTMLAsync();
    }
}
