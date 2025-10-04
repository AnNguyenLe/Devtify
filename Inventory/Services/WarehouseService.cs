using Inventory.ADTs;
using Inventory.Entities;
using Inventory.ServiceContracts;

namespace Inventory.Services;

public class WarehouseService : IWarehouseService
{
    public List<Warehouse[]> OrderProductQuantityBasedSortedWarehouses(List<Warehouse> warehouses, Order order)
    {
        var topProductOrders = new List<Warehouse[]>();
        foreach (var productOrder in order.Products)
        {
            var topMaxHeap = new TopMaxHeap(productOrder.Quantity);
            foreach (var warehouse in warehouses)
            {
                topMaxHeap.Add(warehouse, productOrder.Name);
            }

            topProductOrders.Add(topMaxHeap.GetTopValues());
        }

        return topProductOrders;
    }

    public bool CanFulfillOrder(IEnumerable<Warehouse> selected, Order order)
    {

        var required = order.Products.ToDictionary(p => p.Name, p => p.Quantity);

        foreach (var warehouse in selected)
        {
            foreach (var product in warehouse.Products)
            {
                if (required.ContainsKey(product.Name))
                    required[product.Name] -= product.Quantity;
            }
        }

        return required.Values.All(q => q <= 0);
    }

    public List<Warehouse> FindMinimumWarehouses(List<Warehouse[]> topOrderProductSortedWarehouses, Order order, int maxCombinationCount = 1_000_000)
    {
        var candidates = topOrderProductSortedWarehouses
            .SelectMany(arr => arr)
            .Distinct()
            .ToList();

        List<Warehouse> best = [];

        int combinationCount = 0;
        for (int k = 1; k <= candidates.Count; k++)
        {
            var combinations = GetWarehouseCombinations(candidates, k);
            foreach (var combination in combinations)
            {
                combinationCount++;
                if (combinationCount > maxCombinationCount)
                {
                    break;
                }

                var combinationSet = combination.ToList();
                if (CanFulfillOrder(combinationSet, order))
                {
                    best = combinationSet;
                    break;
                }
            }

            if (best.Count > 0)
            {
                break;
            }
        }

        Console.WriteLine($"Total combinations checked: {combinationCount}");
        return best;
    }

    public IEnumerable<IEnumerable<Warehouse>> GetWarehouseCombinations(List<Warehouse> warehouses, int k)
    {
        if (k == 0)
        {
            yield return Enumerable.Empty<Warehouse>();
            yield break;
        }

        if (k > warehouses.Count || k > 13)
        {
            yield break;
        }

        for (int i = 0; i < warehouses.Count; i++)
        {
            var tails = GetWarehouseCombinations([.. warehouses.Skip(i + 1)], k - 1);
            foreach (var tail in tails)
            {
                yield return new[] { warehouses[i] }.Concat(tail);
            }
        }
    }

    public void PrintReport(Order order, List<Warehouse> minWarehouses)
    {
        Console.WriteLine($"Warehouses used: {minWarehouses.Count}");
        foreach (var wh in minWarehouses)
        {
            Console.WriteLine($"{wh.Name} (ID: {wh.Id})");
        }

        Console.WriteLine("\nOrder details:");
        foreach (var p in order.Products)
        {
            Console.WriteLine($"- {p.Name}: {p.Quantity}");
        }

        Console.WriteLine("\nSelected Warehouses:");
        foreach (var wh in minWarehouses)
        {
            Console.WriteLine($"{wh.Name} (Id: {wh.Id}):");
            foreach (var prod in wh.Products)
            {
                Console.WriteLine($"  {prod.Name}: {prod.Quantity}");
            }
        }
    }
}
