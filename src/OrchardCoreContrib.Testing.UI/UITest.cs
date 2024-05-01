using Microsoft.Playwright;
using OrchardCoreContrib.Testing.UI.Infrastructure;
using Xunit;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a UI testing class.
/// </summary>
/// <param name="browserType">The browser type that will be used during the test. Defaults to <see cref="BrowserType.Edge"/>.</param>
/// <param name="headless">Whether the browser runs in headless mode or not. Defaults to <c>true</c>.</param>
public class UITest(BrowserType browserType = BrowserType.Edge, bool headless = true, int delay = 0) : IAsyncLifetime
{
    private IPlaywright _playwright;

    /// <summary>
    /// Gets the browser instance to be used during the test.
    /// </summary>
    public IBrowser Browser { get; private set; }

    /// <inheritdoc/>
    public async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        Browser = await BrowserFactory.CreateAsync(_playwright, browserType, headless, delay);
    }

    /// <inheritdoc/>
    public async Task DisposeAsync()
    {
        _playwright.Dispose();

        await Task.CompletedTask;
    }
}
