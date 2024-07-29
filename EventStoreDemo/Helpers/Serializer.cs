using System.Text.Json;

namespace EventStoreDemo.Helpers;

internal static class Serializer
{
    public static byte[] SerializeToBytes(object obj) => JsonSerializer.SerializeToUtf8Bytes(obj);

    public static T Deserialize<T>(string asString) => JsonSerializer.Deserialize<T>(asString);
}
