using Microsoft.Playwright;
using PlaywrightBrowser = Microsoft.Playwright.IBrowser;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a factory for creating <see cref="IBrowser"/>.
/// </summary>
public static class BrowserFactory
{
    private static readonly PlaywrightBrowser _chromeBrowser = null;
    private static readonly PlaywrightBrowser _edgeBrowser = null;
    private static readonly PlaywrightBrowser _fireFoxBrowser = null;

    /// <summary>
    /// Creates a new instance of <see cref="IBrowser"/> with a given browser type.
    /// </summary>
    /// <param name="playwright">The <see cref="IPlaywright"/>.</param>
    /// <param name="testOptions">The <see cref="UITestOptions"/>.</param>
    /// <returns>An instance of <see cref="IBrowser"/>.</returns>
    /// <exception cref="NotSupportedException"></exception>
    public static async Task<IBrowser> CreateAsync(IPlaywright playwright, UITestOptions testOptions)
    {
        var browser = testOptions.BrowserType switch
        {
            BrowserType.Edge => _edgeBrowser ?? await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Channel = "msedge",
                Headless = testOptions.Headless
            }),
            BrowserType.Chrome => _chromeBrowser ?? await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = testOptions.Headless
            }),
            BrowserType.Firefox => _fireFoxBrowser ?? await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = testOptions.Headless
            }),
            _ => throw new NotSupportedException()
        };

        return new Browser(new PlaywrightBrowserAccessor(browser)) { Type = testOptions.BrowserType };
    }
}
