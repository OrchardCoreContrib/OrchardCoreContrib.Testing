using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace OrchardCoreContrib.Testing.Logging;

/// <summary>
/// An in-memory logger implementation for testing purposes.
/// </summary>
public class InMemoryLogger : ILogger
{
    private readonly ConcurrentQueue<LogEntry> _logs = new();

    /// <summary>
    /// Gets the logged entries.
    /// </summary>
    public IReadOnlyCollection<LogEntry> Logs => [.. _logs];

    /// <inheritdoc/>
    public IDisposable BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;

    /// <inheritdoc/>
    public bool IsEnabled(LogLevel logLevel) => true;

    /// <inheritdoc/>
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        ArgumentNullException.ThrowIfNull(formatter);

        var message = formatter(state, exception);

        _logs.Enqueue(new LogEntry(logLevel, eventId, message, exception));
    }
}
