# Inventory System

This is a sample .NET 9 console application demonstrating:
- Warehouse allocation for e-commerce orders (minimum warehouse selection)
- Palindrome string checking using extension methods

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed on your machine

## How to Run

1. **Clone or download the repository at [AnNguyenLe/Devtify](https://github.com/AnNguyenLe/Devtify.git)**

2. **Open a terminal and navigate to the project folder:**
   ```
   cd /<path-to-project>/InventorySystem/Inventory
   ```

3. **Restore dependencies (if any):**
   ```
   dotnet restore
   ```

4. **Build the project:**
   ```
   dotnet build
   ```

5. **Run the program:**
   ```
   dotnet run
   ```

## Project Structure

- `Program.cs` - Main entry point, runs both problems and prints results.
- `Data/MockData.cs` - Generates sample warehouses and orders.
- `Entities/` - Domain models for Warehouse, Order, etc.
- `Services/WarehouseService.cs` - Implements warehouse allocation logic and reporting.
- `ServiceContracts/IWarehouseService.cs` - Service interface.
- `ExtensionMethods/StringExtensions.cs` - Palindrome extension method.

## Notes

- The project uses **.NET 9** features.
- No external dependencies are required.
- All logic is contained within the provided source files.

## Output

When you run the program, you will see:
- The minimum set of warehouses needed to fulfill a sample order.
- A report of the order and selected warehouses.
- Palindrome check results for sample strings.
