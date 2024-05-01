using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents an element with a <see cref="IPage"/>.
/// </summary>
/// <remarks>The <see cref="Element"/>.</remarks>
/// <param name="locator">The <see cref="ILocator"/>.</param>
/// <param name="IPage">The <see cref="page"/>.</param>
public class Element(ILocator locator, IPage page) : IElement
{
    private readonly LocatorClickOptions _locatorClickOptions = page.Browser.TestOptions.Delay == 0
        ? null
        : new() { Delay = page.Browser.TestOptions.Delay };
    private readonly LocatorPressSequentiallyOptions _locatorPressSequentiallyOptions = page.Browser.TestOptions.Delay == 0
        ? null
        : new() { Delay = page.Browser.TestOptions.Delay };

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
        await locator.PressSequentiallyAsync(text, _locatorPressSequentiallyOptions);

        InnerText = await locator.InnerTextAsync();
        InnerHtml = await locator.InnerHTMLAsync();
    }
}
