using Inventory.ValueObjects;

namespace Inventory.Entities;

public class Warehouse
{
    public WarehouseId Id { get; init; } = WarehouseId.New();
    public string Name { get; set; } = string.Empty;
    public List<ProductInventory> Products { get; set; } = [];
    public Dictionary<string, long> Inventory => Products.ToDictionary(p => p.Name, p => p.Quantity);
}
