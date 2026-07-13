using Microsoft.Extensions.Logging;

namespace OrchardCoreContrib.Testing.Logging.Tests;

public class InMemoryLoggerTests
{
    [Fact]
    public void Log_ShouldStoreLogEntries()
    {
        // Arrange
        var logger = new InMemoryLogger();

        // Act
        logger.Log(LogLevel.Information, new EventId(1, "TestEvent"), "Test message", null, (state, _) => state.ToString());

        // Assert
        var logs = logger.Logs;
        Assert.Single(logs);

        var logEntry = logs.First();
        Assert.Equal(LogLevel.Information, logEntry.Level);
        Assert.Equal(1, logEntry.EventId.Id);
        Assert.Equal("TestEvent", logEntry.EventId.Name);
        Assert.Equal("Test message", logEntry.Message);
        Assert.Null(logEntry.Exception);
    }

    [Fact]
    public void Log_ShouldThrowArgumentNullException_WhenFormatterIsNull()
    {
        // Arrange
        var logger = new InMemoryLogger();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => logger.Log(LogLevel.Information, new EventId(1, "TestEvent"), "Test message", null, null));
    }

    [Fact]
    public void Logs_ShouldBeEmpty_WhenNoLogsAreAdded()
    {
        // Arrange
        var logger = new InMemoryLogger();

        // Act
        var logs = logger.Logs;

        // Assert
        Assert.Empty(logs);
    }

    [Fact]
    public void BeginScope_ShouldReturnNullScope()
    {
        // Arrange
        var logger = new InMemoryLogger();

        // Act
        var scope = logger.BeginScope("TestScope");

        // Assert
        Assert.NotNull(scope);
        Assert.IsType<NullScope>(scope);
    }

    [Fact]
    public void IsEnabled_ShouldAlwaysReturnTrue()
    {
        // Arrange
        var logger = new InMemoryLogger();

        // Act & Assert
        Assert.True(logger.IsEnabled(LogLevel.Trace));
        Assert.True(logger.IsEnabled(LogLevel.Debug));
        Assert.True(logger.IsEnabled(LogLevel.Information));
        Assert.True(logger.IsEnabled(LogLevel.Warning));
        Assert.True(logger.IsEnabled(LogLevel.Error));
        Assert.True(logger.IsEnabled(LogLevel.Critical));
    }

    [Fact]
    public async Task Logs_ShouldBeThreadSafe()
    {
        // Arrange
        var logger = new InMemoryLogger();
        var tasks = new List<Task>();

        // Act
        for (int i = 0; i < 100; i++)
        {
            int index = i;
            tasks.Add(Task.Run(() => logger.Log(LogLevel.Information, new EventId(index, $"TestEvent{index}"), $"Test message {index}", null, (state, _) => state.ToString())));
        }

        await Task.WhenAll(tasks);

        // Assert
        var logs = logger.Logs;
        Assert.Equal(100, logs.Count);
    }
}
