using Microsoft.Extensions.Logging;

namespace OrchardCoreContrib.Testing.Logging;

/// <summary>
/// An in-memory logger implementation for testing purposes.
/// </summary>
/// <typeparam name="T">The type whose name is used for the logger category.</typeparam>
public class InMemoryLogger<T> : InMemoryLogger, ILogger<T>;
