namespace OrchardCoreContrib.Testing.UI.PageObjects;

/// <summary>
/// Represents the profile page.
/// </summary>
public class ProfilePage : AdminPage
{
    /// <inheritdoc/>
    public override string Slug => "Admin/Users/Edit";

    /// <summary>
    /// Changes the user profile information.
    /// </summary>
    /// <param name="phoneNumber">The phone number.</param>
    /// <param name="roleNames">The user reoles.</param>
    public Task<bool> ChangeAsync(string phoneNumber, params string[] roleNames) => throw new NotImplementedException();
}
