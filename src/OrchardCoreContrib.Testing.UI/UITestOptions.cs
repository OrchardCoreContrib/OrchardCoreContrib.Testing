namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a set of options to be used during the test.
/// </summary>
public class UITestOptions
{
    /// <summary>
    /// Gets or sets whether to run the browser on headless mode. Defaults <c>true</c>.
    /// </summary>
    public bool Headless { get; set; } = true;

    /// <summary>
    /// Gets or sets the browser type to run the test on. Defaults <see cref="BrowserType.Edge"/>.
    /// </summary>
    public BrowserType BrowserType { get; set; } = BrowserType.Edge;

    /// <summary>
    /// Gets or sets amount of time to wait before executing each event on the page. Defaults <c>0</c>.
    /// </summary>
    public int Delay { get; set; } = 0;
}
