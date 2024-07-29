using EventStore.Client;
using EventStoreDemo.Events;
using EventStoreDemo.Helpers;

namespace EventStoreDemo;

public static class EventsWriter
{
    public const string ProductName = "T-Shirt";

    public static async Task WriteEventsAsync(EventStoreClient client, string prefix, int id, CancellationToken cancellationToken)
    {
        var streamName = StreamNameMapper.Map(prefix, id);
        var events = GetEvents(id);

        var writeResult = await client.AppendToStreamAsync(
            streamName,
            StreamState.Any,
            events.Select(ToEventData),
            cancellationToken: cancellationToken
        );
    }

    private static IEnumerable<IEvent> GetEvents(int id)
    {
        yield return new ProductAdded(id, ProductName);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityAdded(id, 1);
        yield return new ProductQuantityRemoved(id, 1);
        yield return new ProductQuantityAdjusted(id, 10);
    }

    private static EventData ToEventData(object @event)
    {
        var eventData = new EventData(
         Uuid.NewUuid(),
         @event.GetType().ToString(),
         Serializer.SerializeToBytes(@event));

        return eventData;
    }
}


