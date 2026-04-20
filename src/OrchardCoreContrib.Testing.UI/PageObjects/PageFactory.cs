namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents a factory for creating page objects.
/// </summary>
public class PageFactory
{
    private static IPage _page;
    private static string _baseUrl;

    /// <summary>
    /// Initializes the page factory.
    /// </summary>
    /// <param name="browser">The <see cref="IBrowser"/>.</param>
    /// <param name="baseUrl">The base URL.</param>
    /// <returns></returns>
    public static async Task InitializeAsync(IBrowser browser, string baseUrl)
    {
        _page = await browser.OpenPageAsync(baseUrl);

        _baseUrl = baseUrl;
    }

    /// <summary>
    /// Creates a page object of the specified type.
    /// </summary>
    /// <typeparam name="TPage">The page type.</typeparam>
    public static async Task<TPage> CreateAsync<TPage>() where TPage : PageBase
    {
        var page = Activator.CreateInstance<TPage>();

        page.Page = _page;
        page.BaseUrl = _baseUrl;

        return (TPage)await page.GoToAsync();
    }
}
