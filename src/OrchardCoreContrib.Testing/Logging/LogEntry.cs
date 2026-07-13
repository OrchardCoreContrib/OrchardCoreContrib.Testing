using Microsoft.Extensions.Logging;

namespace OrchardCoreContrib.Testing.Logging;

/// <summary>
/// Represents a log record.
/// </summary>
/// <param name="Level">The log level.</param>
/// <param name="EventId">The event ID.</param>
/// <param name="Message">The log message.</param>
/// <param name="Exception">The exception associated with the log entry, if any.</param>
public record LogEntry(LogLevel Level, EventId EventId, string Message, Exception Exception);
