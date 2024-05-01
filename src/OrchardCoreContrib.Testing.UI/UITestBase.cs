using Microsoft.Playwright;

namespace OrchardCoreContrib.Testing.UI;

public abstract class UITestBase(UITestOptions testOptions) : IUITest
{
    private IPlaywright _playwright;

    /// <summary>
    /// Gets or sets the browser instance to be used during the test.
    /// </summary>
    public IBrowser Browser { get; set; }

    /// <summary>
    /// Gets the options used during the test.
    /// </summary>
    public UITestOptions Options => testOptions;

    /// <inheritdoc/>
    public virtual async Task InitializeAsync()
    {
        _playwright = await Playwright.CreateAsync();

        Browser = await BrowserFactory.CreateAsync(_playwright, Options);
    }

    /// <inheritdoc/>
    public virtual async Task DisposeAsync()
    {
        _playwright.Dispose();

        await Task.CompletedTask;
    }
}
