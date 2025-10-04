namespace Inventory.ValueObjects;

public sealed record WarehouseId(Guid Value)
    : IComparable<WarehouseId>
{
    public static WarehouseId New() => new(Guid.CreateVersion7());

    public int CompareTo(WarehouseId? other)
    {
        return other is null ?
            throw new ArgumentNullException(nameof(other)) :
            Value.CompareTo(other.Value);
    }

    public override string ToString() => Value.ToString();
}
