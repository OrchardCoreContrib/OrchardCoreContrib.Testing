namespace OrchardCoreContrib.Testing.UI.Tests;

public class ElementTests
{
    [Fact]
    public void GetElementInformation()
    {
        // Act
        var element = new Element(Mock.Of<ILocator>())
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
        var element = new Element(locatorMock.Object);

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
        locatorMock.Setup(l => l.FillAsync(It.IsAny<string>(), null))
            .Callback(() =>
            {
                locatorMock.Setup(l => l.InnerTextAsync(null))
                    .ReturnsAsync("Orchard Core Contrib");
            });
        var element = new Element(locatorMock.Object);

        // Act
        await element.TypeAsync("Orchard Core Contrib");

        // Assert
        Assert.Equal("Orchard Core Contrib", element.InnerText);
    }
}
