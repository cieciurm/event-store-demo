using System.Text;
using EventStore.Client;
using EventStoreDemo.Events;
using EventStoreDemo.Helpers;

namespace EventStoreDemo;

public static class EventsReader
{
    public static async Task<List<IEvent>> ReadEventsAsync(EventStoreClient client, string prefix, int id)
    {
        var streamName = StreamNameMapper.Map(prefix, id);
        var result = client.ReadStreamAsync(
                    Direction.Forwards,
                    streamName,
                    StreamPosition.Start);

        var events = new List<IEvent>();

        await foreach (var resolvedEvt in result)
        {
            var @event = resolvedEvt.Event;
            var binaryData = @event.Data.ToArray();

            var evtString = Encoding.UTF8.GetString(binaryData);

            switch (@event.EventType)
            {
                case nameof(ProductAdded):
                    events.Add(Serializer.Deserialize<ProductAdded>(evtString));
                    break;
                case nameof(ProductQuantityAdded):
                    events.Add(Serializer.Deserialize<ProductQuantityAdded>(evtString));
                    break;
                case nameof(ProductQuantityRemoved):
                    events.Add(Serializer.Deserialize<ProductQuantityRemoved>(evtString));
                    break;
                case nameof(ProductQuantityAdjusted):
                    events.Add(Serializer.Deserialize<ProductQuantityAdjusted>(evtString));
                    break;
            }
        }

        return events;
    }
}
