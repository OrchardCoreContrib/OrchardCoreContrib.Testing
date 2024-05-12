using Microsoft.Playwright;
using OrchardCoreContrib.Testing.UI.Helpers;

namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents a base class for admin page objects.
/// </summary>
public abstract class AdminPage : PageBase
{
    /// <inheritdoc/>
    public abstract override string Slug { get; }

    /// <summary>
    /// Changes the theme.
    /// </summary>
    /// <param name="themeMode">The theme mode to be applied.</param>
    public async Task ChangeThemeAsync(ThemeMode themeMode)
    {
        await Page.FindElement(By.Id("bd-theme")).ClickAsync();
        await Page.FindElement(By.Attribute("data-bs-theme-value", themeMode.ToString().ToLower(), "button")).ClickAsync();
    }

    /// <summary>
    /// Navigates to the profile page.
    /// </summary>
    public async Task<ProfilePage> GoToProfilePage() => await PageFactory.CreateAsync<ProfilePage>();

    /// <summary>
    /// Navigates to the change password page.
    /// </summary>
    public async Task<ChangePasswordPage> GoToChangePasswordPage() => await PageFactory.CreateAsync<ChangePasswordPage>();

    /// <summary>
    /// Log out the current user.
    /// </summary>
    public async Task LogoutAsync()
    {
        await Page.InnerPage.GetByRole(AriaRole.Link, new() { Name = "admin" }).ClickAsync();
        await Page.InnerPage.GetByRole(AriaRole.Button, new() { Name = "Log off" }).ClickAsync();
    }
}
