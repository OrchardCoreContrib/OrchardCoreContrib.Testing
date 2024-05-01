using PlaywrightBrowserType = Microsoft.Playwright.BrowserType;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class BrowserFactoryTests
{
    [InlineData(BrowserType.Chrome, PlaywrightBrowserType.Chromium)]
    [InlineData(BrowserType.Edge, PlaywrightBrowserType.Chromium)]
    [InlineData(BrowserType.Firefox, PlaywrightBrowserType.Firefox)]
    [Theory]
    public async Task CreateBrowser(BrowserType browserType, string playwrightBrowserType)
    {
        // Arrange
        var playwright = await Playwright.CreateAsync();

        var testOptions = new UITestOptions
        {
            BrowserType = browserType
        };

        // Act
        var browser = await BrowserFactory.CreateAsync(playwright, testOptions);
        browser.Type = browserType;

        // Assert
        Assert.NotNull(browser);
        Assert.Equal(browserType, browser.Type);
        Assert.Equal(playwrightBrowserType, browser.InnerBrowser.BrowserType.Name);
    }

    [Fact]
    public async Task CreateBrowser_ThrowsException_WhenBrowserTypeInvalid()
    {
        // Arrange
        var playwright = await Playwright.CreateAsync();
        var testOptions = new UITestOptions
        {
            BrowserType = BrowserType.NotSet
        };

        // Act & Assert
        await Assert.ThrowsAsync<NotSupportedException>(async () =>
        {
            await BrowserFactory.CreateAsync(playwright, testOptions);
        });
    }
}
