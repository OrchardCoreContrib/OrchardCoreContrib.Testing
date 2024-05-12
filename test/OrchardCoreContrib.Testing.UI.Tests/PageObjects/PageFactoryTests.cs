namespace OrchardCoreContrib.Testing.UI.PageObjects.Tests;

public class PageFactoryTests
{
    [Fact]
    public async Task CreatePage()
    {
        // Arrange
        var baseUrl = "https://localhost:8080";
        var browserMock = new Mock<IBrowser>();
        browserMock.Setup(b => b.OpenPageAsync(It.IsAny<string>()))
            .ReturnsAsync(() => new Page(new PlaywrightPageAccessor(Mock.Of<Microsoft.Playwright.IPage>()), browserMock.Object));

        await PageFactory.InitializeAsync(browserMock.Object, baseUrl);

        // Act
        var page = await PageFactory.CreateAsync<MyPage>();

        // Assert
        Assert.NotNull(page.Page);
        Assert.Equal(baseUrl, page.BaseUrl);
        Assert.Equal("/my-page", page.Slug);
    }

    public class MyPage(IPage page) : PageBase(page)
    {
        public override string Slug => "/my-page";
    }
}
