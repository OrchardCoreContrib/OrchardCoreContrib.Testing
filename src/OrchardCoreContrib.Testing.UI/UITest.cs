namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a UI testing class.
/// </summary>
/// <param name="browserType">The browser type that will be used during the test. Defaults to <see cref="BrowserType.Edge"/>.</param>
/// <param name="headless">Whether the browser runs in headless mode or not. Defaults to <c>true</c>.</param>
/// <param name="delay">The amount of time to wait between execute two actions. Defaults to <c>0</c>.</param>
public class UITest(BrowserType browserType = BrowserType.Edge, bool headless = true, int delay = 0)
    : UITestBase(new UITestOptions
    {
        BrowserType = browserType,
        Headless = headless,
        Delay = delay
    })
{
}
