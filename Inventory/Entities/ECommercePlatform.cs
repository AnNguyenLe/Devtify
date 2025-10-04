namespace Inventory.Entities;

/*
Một hệ thống e-commerce nhận được một đơn hàng gồm nhiều loại sản phẩm với số lượng cụ thể.
Mỗi kho hàng có một danh sách sản phẩm và số lượng tồn kho.
Cần viết thuật toán phân bổ  sao cho:
1.	Số lượng kho dùng là ít nhất để gom đủ hàng.
2.	Nếu có nhiều phương án cùng số lượng kho, thì chọn phương án theo thứ tự ưu tiên (ưu tiên kho có thứ tự nhỏ hơn).

*/

public class ECommercePlatform
{
    public List<Warehouse> Warehouses { get; set; } = [];
}
