﻿using PlaywrightBrowserType = Microsoft.Playwright.BrowserType;

namespace OrchardCoreContrib.Testing.UI.Tests;

public class BrowserFactoryTests
{
    [InlineData(BrowserType.Chrome, PlaywrightBrowserType.Chromium, false)]
    [InlineData(BrowserType.Edge, PlaywrightBrowserType.Chromium, false)]
    [InlineData(BrowserType.Firefox, PlaywrightBrowserType.Firefox, false)]
    [InlineData(BrowserType.Chrome, PlaywrightBrowserType.Chromium, true)]
    [InlineData(BrowserType.Edge, PlaywrightBrowserType.Chromium, true)]
    [InlineData(BrowserType.Firefox, PlaywrightBrowserType.Firefox, true)]
    [Theory]
    public async Task CreateBrowser(BrowserType browserType, string playwrightBrowserType, bool headless)
    {
        // Arrange
        var playwright = await Playwright.CreateAsync();

        // Act
        var browser = await BrowserFactory.CreateAsync(playwright, browserType, headless, delay: 0);

        // Assert
        Assert.NotNull(browser);
        Assert.Equal(browserType, browser.Type);
        Assert.Equal(playwrightBrowserType, browser.InnerBrowser.BrowserType.Name);
        Assert.Equal(headless, browser.Headless);
    }

    [Fact]
    public async Task CreateBrowser_ThrowsException_WhenBrowserTypeInvalid()
    {
        // Arrange
        var playwright = await Playwright.CreateAsync();

        // Act & Assert
        await Assert.ThrowsAsync<NotSupportedException>(async () =>
        {
            await BrowserFactory.CreateAsync(playwright, BrowserType.NotSet, headless: true, delay: 0);
        });
    }
}
