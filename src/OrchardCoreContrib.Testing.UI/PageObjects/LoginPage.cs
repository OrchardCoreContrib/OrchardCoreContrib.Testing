using Microsoft.Playwright;
using OrchardCoreContrib.Testing.UI.Helpers;

namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents a login page.
/// </summary>
/// <param name="page">The <see cref="IPage"/>.</param>
public class LoginPage(IPage page) : PageBase(page)
{
    /// <inheritdoc/>
    public override string Slug => "Login";

    /// <summary>
    /// Logs in with the specified username and password.
    /// </summary>
    /// <param name="username">The user name.</param>
    /// <param name="password">The password.</param>
    public async Task<bool> LoginAsync(string username, string password)
    {
        await Page.FindElement(By.Attribute("name", "UserName")).TypeAsync(username);
        await Page.FindElement(By.Attribute("name", "Password")).TypeAsync(password);
        await Page.FindElement(By.Attribute("type", "submit")).ClickAsync();

        var isAuthenticated = await Page.InnerPage
            .GetByRole(AriaRole.Link, new() { Name = username })
            .IsVisibleAsync();

        return isAuthenticated;
    }
}
