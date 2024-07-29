using EventStoreDemo.Events;

namespace EventStoreDemo.Aggregates;

public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; } = "";

    public int Quantity { get; set; }

    public void Evolve(IEvent @event)
    {
        switch (@event)
        {
            case ProductAdded productAdded:
                Apply(productAdded);
                break;
            case ProductQuantityAdded productQuantityAdded:
                Apply(productQuantityAdded);
                break;
            case ProductQuantityRemoved productQuantityRemoved:
                Apply(productQuantityRemoved);
                break;
            case ProductQuantityAdjusted productQuantityAdjusted:
                Apply(productQuantityAdjusted);
                break;
        }
    }

    private void Apply(ProductAdded @event)
    {
        Id = @event.Id;
        ProductName = @event.ProductName;
    }

    private void Apply(ProductQuantityAdded @event)
    {
        Quantity += @event.Quantity;
    }

    private void Apply(ProductQuantityRemoved @event)
    {
        Quantity -= @event.Quantity;
    }

    private void Apply(ProductQuantityAdjusted @event)
    {
        Quantity = @event.Quantity;
    }

    public override string ToString()
    {
        return $"{{ Id: {Id},  ProductName: {ProductName}, Quantity: {Quantity} }}";
    }
}
