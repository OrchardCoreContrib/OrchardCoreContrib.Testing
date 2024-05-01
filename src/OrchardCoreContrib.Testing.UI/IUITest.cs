using Xunit;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a contract for UI test.
/// </summary>
public interface  IUITest : IAsyncLifetime
{
    /// <summary>
    /// Gets or sets the browser instance to be used during the test.
    /// </summary>
    public IBrowser Browser { get; set; }

    /// <summary>
    /// Gets the options used during the test.
    /// </summary>
    public UITestOptions Options { get; }
}
