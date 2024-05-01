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
    public string InnerText => locator.InnerTextAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public string InnerHtml => locator.InnerHTMLAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public bool Enabled => locator.IsEnabledAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public bool Visible => locator.IsVisibleAsync().GetAwaiter().GetResult();

    /// <inheritdoc/>
    public async Task ClickAsync() => await locator.ClickAsync(_locatorClickOptions);

    /// <inheritdoc/>
    public async Task TypeAsync(string text) => await locator.PressSequentiallyAsync(text, _locatorPressSequentiallyOptions);
}
