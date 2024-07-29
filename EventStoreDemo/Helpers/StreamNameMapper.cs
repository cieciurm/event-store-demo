namespace EventStoreDemo.Helpers;

internal static class StreamNameMapper
{
    public static string Map(string streamPrefix, int id) => $"{streamPrefix}-{id}";
}
