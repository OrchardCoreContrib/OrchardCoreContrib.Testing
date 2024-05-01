﻿using Microsoft.Playwright;
using Xunit;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a UI testing class.
/// </summary>
/// <param name="browserType">The browser type that will be used during the test. Defaults to <see cref="BrowserType.Edge"/>.</param>
/// <param name="headless">Whether the browser runs in headless mode or not. Defaults to <c>true</c>.</param>
public class UITest(BrowserType browserType = BrowserType.Edge, bool headless = true) : IAsyncLifetime
{
    private IPlaywright _playwright;

    /// <summary>
    /// Gets the browser instance to be used during the test.
    /// </summary>
    public IBrowser Browser { get; private set; }

    public UITestOptions Options { get; private set; }

    /// <inheritdoc/>
    public async Task InitializeAsync()
    {
        Options = new UITestOptions
        {
            BrowserType = browserType,
            Headless = headless
        };

        _playwright = await Playwright.CreateAsync();

        Browser = await BrowserFactory.CreateAsync(_playwright, Options);
    }

    /// <inheritdoc/>
    public async Task DisposeAsync()
    {
        _playwright.Dispose();

        await Task.CompletedTask;
    }
}
