using Inventory.Entities;
using Inventory.ValueObjects;

namespace Inventory.Data;

public static class MockData
{
    public static List<Warehouse> GenerateWarehouses(int count = 120)
    {
        var productNames = new[] { "Product X", "Product Y", "Product Z", "Product A", "Product B" };
        var warehouses = new List<Warehouse>();

        var rand = new Random(42);

        for (int i = 1; i <= count; i++)
        {
            var products = new List<ProductInventory>();
            foreach (var name in productNames)
            {
                products.Add(new ProductInventory
                {
                    Id = ProductInventoryId.New(),
                    Name = name,
                    Quantity = rand.Next(0, 150)
                });
            }

            warehouses.Add(new Warehouse
            {
                Id = WarehouseId.New(),
                Name = $"Warehouse {i}",
                Products = products
            });
        }

        return warehouses;
    }

    public static Order GenerateOrder()
    {
        return new Order
        {
            Products =
            [
                new ProductOrder { Name = "Product X", Quantity = 350 },
                new ProductOrder { Name = "Product Y", Quantity = 300 },
                new ProductOrder { Name = "Product Z", Quantity = 280 },
                new ProductOrder { Name = "Product A", Quantity = 260 },
                new ProductOrder { Name = "Product B", Quantity = 240 }
            ]
        };
    }
}