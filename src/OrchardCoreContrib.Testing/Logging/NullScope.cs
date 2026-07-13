namespace OrchardCoreContrib.Testing.Logging;

internal class NullScope : IDisposable
{
    public static readonly NullScope Instance = new();

    public void Dispose() { }
}
