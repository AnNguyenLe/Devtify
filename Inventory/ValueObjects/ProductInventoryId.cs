namespace Inventory.ValueObjects;

public sealed record ProductInventoryId(Guid Value)
{
    public static ProductInventoryId New() => new(Guid.CreateVersion7());
    public override string ToString() => Value.ToString();
}
