namespace OrchardCoreContrib.Testing.UI.Tests;

public class PageTests
{
    private readonly IBrowser _browser = Mock.Of<IBrowser>();

    [Fact]
    public void ShouldCreatePage()
    {
        // Arrange
        var playwrightPageAccessor = new PlaywrightPageAccessor(Mock.Of<Microsoft.Playwright.IPage>());

        // Act
        var page = new Page(_browser, playwrightPageAccessor);

        // Assert
        Assert.NotNull(page);
        Assert.Same(playwrightPageAccessor.PlaywrightPage, page.InnerPage);
    }

    [Fact]
    public async Task GetPageInformation()
    {
        // Arrange
        var pageMock = new Mock<Microsoft.Playwright.IPage>();
        pageMock.Setup(p => p.GotoAsync(It.IsAny<string>(), null))
            .ReturnsAsync(Mock.Of<IResponse>());
        pageMock.Setup(p => p.TitleAsync())
            .ReturnsAsync("Orchard Core Contrib");
        pageMock.Setup(p => p.ContentAsync())
            .ReturnsAsync("<h1>Welcome to Orchard Core Contrib (OCC)</h1>");

        var playwrightPageAccessor = new PlaywrightPageAccessor(pageMock.Object);

        // Act
        var page = new Page(_browser, playwrightPageAccessor);
        await page.GoToAsync("www.occ.com");

        // Assert
        Assert.Equal("Orchard Core Contrib", page.Title);
        Assert.Equal("<h1>Welcome to Orchard Core Contrib (OCC)</h1>", page.Content);
    }

    [Fact]
    public void ShouldFindElement()
    {
        // Arrange
        var pageMock = new Mock<Microsoft.Playwright.IPage>();

        pageMock.Setup(p => p.Locator(It.IsAny<string>(), null))
            .Returns(Mock.Of<ILocator>());

        var playwrightPageAccessor = new PlaywrightPageAccessor(pageMock.Object);

        var page = new Page(_browser, playwrightPageAccessor);

        // Act
        var result = page.FindElement("selector");

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task ShouldClickAnElement()
    {
        // Arrange
        var page = await PlaywrightPageHelper.GotoAsync("index.html");

        // Act
        await page.ClickAsync("button");

        // Assert
        var paragraph = page.FindElement("#para");
        Assert.Equal("The button is clicked!!", paragraph.InnerText);
    }

    [Fact]
    public async Task ShouldTakeScreenshot()
    {
        // Arrange
        var screenshotFilePath = "screenshot.jpg";

        var page = await PlaywrightPageHelper.GotoAsync("index.html");

        // Act
        await page.ScreenShotAsync(screenshotFilePath);

        // Assert
        Assert.True(File.Exists(screenshotFilePath));
        File.Delete(screenshotFilePath);
    }
}