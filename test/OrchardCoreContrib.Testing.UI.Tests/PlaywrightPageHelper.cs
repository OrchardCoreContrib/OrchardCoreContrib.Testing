namespace OrchardCoreContrib.Testing.UI.Tests;

internal class PlaywrightPageHelper
{
    public static async Task<IPage> GotoAsync(string pageName)
    {
        var playwright = await Playwright.CreateAsync();
        var playwrightBrowser = await playwright.Chromium.LaunchAsync();
        var browser = new Browser(new PlaywrightBrowserAccessor(playwrightBrowser))
        {
            TestOptions = new UITestOptions()
        };

        var page = await playwrightBrowser.NewPageAsync();

        await page.GotoAsync(PageHelper.GetFullPath(pageName));

        return new Page(new PlaywrightPageAccessor(page), browser);
    }
}
