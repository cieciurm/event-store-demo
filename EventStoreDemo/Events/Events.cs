namespace EventStoreDemo.Events;

public interface IEvent { }

record ProductAdded(int Id, string ProductName) : IEvent;
record ProductQuantityAdded(int Id, int Quantity) : IEvent;
record ProductQuantityRemoved(int Id, int Quantity) : IEvent;
record ProductQuantityAdjusted(int Id, int Quantity) : IEvent;