namespace OrchardCoreContrib.Testing.UI.Tests;

public class UITestTests : UITest
{
    [Fact]
    public async Task RunTest()
    {
        // Arrange
        var test = new UITest();

        // Act
        await test.InitializeAsync();

        // Assert
        Assert.NotNull(test.Browser);
    }

    [Fact]
    public async Task NavigateToHomePage()
    {
        // Arrange
        var url = PageHelper.GetFullPath("index.html");
        // Act
        var page = await Browser.OpenPageAsync(url);

        // Assert
        Assert.Contains("Orchard Core Contrib", page.Title);
    }
}
