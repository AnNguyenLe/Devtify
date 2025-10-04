using Inventory.Entities;

namespace Inventory.ADTs;

public class TopMaxHeap(long capacity)
{
    private readonly PriorityQueue<QueueItem, long> _minHeap = new();
    private readonly long _capacity = capacity;

    public void Add(Warehouse warehouse, string productName)
    {
        if (warehouse.Inventory.TryGetValue(productName, out var quantity))
        {
            if (_minHeap.Count < _capacity)
            {
                _minHeap.Enqueue(new QueueItem(warehouse, quantity), quantity);
            }
            else if (quantity > _minHeap.Peek().Quantity)
            {
                _minHeap.Dequeue();
                _minHeap.Enqueue(new QueueItem(warehouse, quantity), quantity);
            }
        }
    }

    public Warehouse[] GetTopValues()
    {
        var result = new Warehouse[_minHeap.Count];

        while (_minHeap.Count > 0)
        {
            result[_minHeap.Count - 1] = _minHeap.Dequeue().Warehouse;
        }

        return result;
    }
}

record QueueItem(Warehouse Warehouse, long Quantity);

