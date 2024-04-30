namespace OrchardCoreContrib.Testing.UI.Tests;

internal class PlaywrightPageHelper
{
    public static async Task<IPage> GotoAsync(string pageName)
    {
        var playwright = await Playwright.CreateAsync();
        var browser = await playwright.Chromium.LaunchAsync();

        var page = await browser.NewPageAsync();

        await page.GotoAsync(PageHelper.GetFullPath(pageName));

        return new Page(new PlaywrightPageAccessor(page));
    }
}
