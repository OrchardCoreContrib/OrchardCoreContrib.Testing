namespace OrchardCoreContrib.Testing.UI.Tests;

public class ElementTests
{
    private readonly Mock<Page> _pageMock;

    public ElementTests()
    {
        var playwrightPage = Mock.Of<Microsoft.Playwright.IPage>();
        var playwrightPageAccessorMock = new Mock<PlaywrightPageAccessor>(playwrightPage);
        _pageMock = new(Mock.Of<IBrowser>(), playwrightPageAccessorMock.Object);
        //_pageMock.Setup(p => p.InnerPage)
        //    .Returns(playwrightPage);
    }

    [Fact]
    public void GetElementInformation()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        locatorMock.Setup(l => l.InnerHTMLAsync(null))
            .ReturnsAsync("<h1>Orchard Core Contrib</h1>");

        locatorMock.Setup(l => l.InnerTextAsync(null))
            .ReturnsAsync("Orchard Core Contrib");

        locatorMock.Setup(l => l.IsDisabledAsync(null))
            .ReturnsAsync(false);

        locatorMock.Setup(l => l.IsVisibleAsync(null))
            .ReturnsAsync(true);

        // Act
        var element = new Element(_pageMock.Object, locatorMock.Object);

        // Assert
        Assert.Equal("<h1>Orchard Core Contrib</h1>", element.InnerHtml);
        Assert.Equal("Orchard Core Contrib", element.InnerText);
        Assert.False(element.Enabled);
        Assert.True(element.Visible);
    }

    [Fact]
    public async Task ClickElement()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        var element = new Element(_pageMock.Object, locatorMock.Object);

        // Act
        await element.ClickAsync();

        // Assert
        locatorMock.Verify(l => l.ClickAsync(null), Times.Once);
    }

    [Fact]
    public async Task TypeTextIntoElement()
    {
        // Arrange
        var locatorMock = new Mock<ILocator>();
        locatorMock.Setup(l => l.PressSequentiallyAsync(It.IsAny<string>(), null))
            .Callback(() =>
            {
                locatorMock.Setup(l => l.InnerTextAsync(null))
                    .ReturnsAsync("Orchard Core Contrib");
            });
        var element = new Element(_pageMock.Object, locatorMock.Object);

        // Act
        await element.TypeAsync("Orchard Core Contrib");

        // Assert
        Assert.Equal("Orchard Core Contrib", element.InnerText);
    }
}
