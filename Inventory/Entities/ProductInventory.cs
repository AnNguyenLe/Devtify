using Inventory.ValueObjects;

namespace Inventory.Entities;

public class ProductInventory
{
    public ProductInventoryId Id { get; init; } = ProductInventoryId.New();
    public string Name { get; set; } = string.Empty;
    public long Quantity { get; set; }
}
