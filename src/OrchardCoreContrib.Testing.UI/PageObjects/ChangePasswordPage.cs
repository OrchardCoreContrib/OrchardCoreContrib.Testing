using OrchardCoreContrib.Testing.UI.Helpers;

namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents a change password page.
/// </summary>
/// <param name="page">The <see cref="IPage"/>.</param>
public class ChangePasswordPage(IPage page) : AdminPage(page)
{
    /// <inheritdoc/>
    public override string Slug => "ChangePassword";

    /// <summary>
    /// Changes the user password.
    /// </summary>
    /// <param name="currentPassword">The current password.</param>
    /// <param name="newPassword">The new password.</param>
    public async Task<bool> ChangeAsync(string currentPassword, string newPassword)
    {
        await Page.FindElement(By.Attribute("name", "CurrentPassword")).TypeAsync(currentPassword);
        await Page.FindElement(By.Attribute("name", "Password")).TypeAsync(newPassword);
        await Page.FindElement(By.Attribute("name", "PasswordConfirmation")).TypeAsync(newPassword);
        await Page.FindElement(By.Attribute("type", "submit", "button")).ClickAsync();

        return Page.Content.Contains("Your password has been changed successfully.");
    }
}
