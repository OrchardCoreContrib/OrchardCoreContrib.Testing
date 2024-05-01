namespace OrchardCoreContrib.Testing.UI.Tests;

public class ElementTests
{
    private readonly Page _page;

    public ElementTests()
    {
        var browser = new Browser(new PlaywrightBrowserAccessor(Mock.Of<Microsoft.Playwright.IBrowser>()))
        {
            TestOptions = new UITestOptions()
        };
        _page = new Page(new PlaywrightPageAccessor(Mock.Of<Microsoft.Playwright.IPage>()), browser);
    }

    [Fact]
    public void GetElementInformation()
    {
        // Act
        var element = new Element(Mock.Of<ILocator>(), _page)
        {
            InnerHtml = "<h1>Orchard Core Contrib</h1>",
            InnerText = "Orchard Core Contrib",
            Enabled = false,
            Visible = true
        };

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
        var element = new Element(locatorMock.Object, _page);

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
        var element = new Element(locatorMock.Object, _page);

        // Act
        await element.TypeAsync("Orchard Core Contrib");

        // Assert
        Assert.Equal("Orchard Core Contrib", element.InnerText);
    }
}
