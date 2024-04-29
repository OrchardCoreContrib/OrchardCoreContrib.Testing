using OrchardCoreContrib.Testing.UI.Tests;

namespace OrchardCoreContrib.Testing.UI.Helpers.Tests;

public class CssSelectorsTests
{
    public static readonly IEnumerable<object[]> CombinatorsData =
    [
        new [] { By.Id("container") },
        new [] { By.TagName("body") },
        new [] { By.ClassName("red") },
        new [] { By.ClassName("red", "p") },
        new [] { By.Attribute("class") },
        new [] { By.Attribute("class", elementName: "p") },
        new [] { By.Attribute("class", "red") },
        new [] { By.Attribute("class", "red", "p") },
        new [] { By.AttributeContains("id", "con") },
        new [] { By.AttributeContains("id", "con", "div") },
        new [] { By.AttributeStartsWith("class", "re") },
        new [] { By.AttributeStartsWith("class", "re", "p") },
        new [] { By.AttributeEndsWith("class", "ed") },
        new [] { By.AttributeEndsWith("class", "ed", "p") },
        new [] { By.Descendant("div", "p") },
        new [] { By.Descendant("div", "a", direct: true) },
        new [] { By.Sibling("div", "h3") },
        new [] { By.Sibling("div", "p", adjacent: true) },
        //new [] { By.PseudoElement("marker") },
        //new [] { By.PseudoElement("first-line", "p.red") },
        new [] { By.PseudoClass("disabled") },
        new [] { By.PseudoClass("disabled", "input") },
    ];

    [MemberData(nameof(CombinatorsData))]
    [Theory]
    public async Task ShouldFindByCssSelector(string selector)
    {
        // Arrange
        var page = await PlaywrightPageHelper.GotoAsync("selectors.html");

        // Act
        var element = page.FindElement(selector);

        // Assert
        Assert.True(element.Visible);
    }
}
