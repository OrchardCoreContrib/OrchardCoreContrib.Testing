using OrchardCoreContrib.Testing.UI.Infrastructure;

namespace OrchardCoreContrib.Testing.UI;

/// <summary>
/// Represents a UI testing class that extends <see cref="UITestBase{TStartup}"/>.
/// </summary>
/// <param name="browserType">The browser type that will be used during the test. Defaults to <see cref="BrowserType.Edge"/>.</param>
/// <param name="headless">Whether the browser runs in headless mode or not. Defaults to <c>true</c>.</param>
/// <param name="delay">The amount of time to wait between execute two actions. Defaults to <c>0</c>.</param>
/// <typeparam name="TStartup">The startup class type that will be used as entry point.</typeparam>
public class UITest<TStartup>(BrowserType browserType = BrowserType.Edge, bool headless = true, int delay = 0) :
    UITestBase<TStartup>(new WebApplicationFactoryFixture<TStartup>(), new UITestOptions
    {
        BrowserType = browserType,
        Headless = headless,
        Delay = delay
    }), IUITest where TStartup : class
{
}
