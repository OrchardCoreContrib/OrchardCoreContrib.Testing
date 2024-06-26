﻿namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for a page.
/// </summary>
public interface IPage
{
    /// <summary>
    /// Gets the inner playwright page instance.
    /// </summary>
    public Microsoft.Playwright.IPage InnerPage { get; }

    internal IBrowser Browser { get; }

    /// <summary>
    /// Gets or sets the page title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the page content in HTML format.
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    /// Navigates to a given URL.
    /// </summary>
    /// <param name="url">The url to be redirected.</param>
    public Task GoToAsync(string url);

    /// <summary>
    /// Finds an element with a page using a given selector.
    /// </summary>
    /// <param name="selector">A selector to be used to look for the element within the page.</param>
    public IElement FindElement(string selector);

    /// <summary>
    /// Clicks an element with a given selector.
    /// </summary>
    /// <param name="selector"></param>
    public Task ClickAsync(string selector);

    /// <summary>
    /// Takes a screenshot of the page.
    /// </summary>
    /// <param name="path">The path for the saved image.</param>
    /// <param name="fullPage">Whether the screenshot taken for a full page or a vidible view port.</param>
    public Task ScreenShotAsync(string path, bool fullPage = false);
}
