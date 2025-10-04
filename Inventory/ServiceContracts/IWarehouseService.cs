using Inventory.Entities;

namespace Inventory.ServiceContracts;

public interface IWarehouseService
{
    List<Warehouse[]> OrderProductQuantityBasedSortedWarehouses(List<Warehouse> warehouses, Order order);
    bool CanFulfillOrder(IEnumerable<Warehouse> selected, Order order);
    List<Warehouse> FindMinimumWarehouses(List<Warehouse[]> topOrderProductSortedWarehouses, Order order, int maxCombinationCount = 1_000_000);
    IEnumerable<IEnumerable<Warehouse>> GetWarehouseCombinations(List<Warehouse> warehouses, int k);
    void PrintReport(Order order, List<Warehouse> minWarehouses);
}
