using Inventory.Data;
using Inventory.ExtensionMethods;
using Inventory.Services;

Console.WriteLine("========== Problem 1: Warehouse Selection ==========");
/*
Problem 1:

An e-commerce system receives an order consisting of multiple types of products, each with a specified quantity.

Each warehouse has a list of products and the corresponding stock quantities.

You need to write an allocation algorithm such that:

1. The number of warehouses used is minimized while still fulfilling the entire order.

2. If there are multiple solutions using the same number of warehouses, choose the one with higher priority based on warehouse order (i.e., prefer warehouses with lower indices).
*/
var warehouseService = new WarehouseService();

var warehouses = MockData.GenerateWarehouses();
var order = MockData.GenerateOrder();

var topOrderProductSortedWarehouses = warehouseService.OrderProductQuantityBasedSortedWarehouses(warehouses, order);

var minWarehouses = warehouseService.FindMinimumWarehouses(topOrderProductSortedWarehouses, order)
    .OrderBy(wh => wh.Id.ToString(), StringComparer.Ordinal)
    .ToList();

warehouseService.PrintReport(order, minWarehouses);


Console.WriteLine("\n========== Problem 2: Palindrome Check ==========");
/*
Problem 2:

Check whether a string is a palindrome or not.

The description of the pure function is:

Input: s <str> (hidden input param thanks to method extension)

Output: true / false
*/

// This function only considers the characters which are letter or digit
var text1 = "A man, a plan, a canal: Panama";
var text2 = "re4324er";
Console.WriteLine($"Is text: '{text1}' a palindrome? => {text1.IsPalindrome()}");
Console.WriteLine($"Is text: '{text2}' a palindrome? => {text2.IsPalindrome()}");
