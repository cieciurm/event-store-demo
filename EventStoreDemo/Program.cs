using EventStore.Client;
using EventStoreDemo;
using EventStoreDemo.Aggregates;

var tokenSource = new CancellationTokenSource();
const string connectionString = "esdb://admin:changeit@localhost:2113?tls=false&tlsVerifyCert=false";

const string prefix = "product";
const int productId = 10;

// Create EventStore client
var settings = EventStoreClientSettings.Create(connectionString);
var client = new EventStoreClient(settings);

// Write events to a stream
// await EventsWriter.WriteEvents(client, prefix, productId, tokenSource.Token);

// Read events
var events = await EventsReader.ReadEventsAsync(client, prefix, productId);

// Create aggregate
var product = new Product();

foreach (var evt in events)
{
    product.Evolve(evt);
}

Console.WriteLine(product);
Console.ReadLine();
