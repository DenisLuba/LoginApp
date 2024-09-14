using SQLite;

namespace MyLoginApp.Models;

public class ProductInfo
{
    [PrimaryKey, AutoIncrement]
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public int? ProductQty { get; set; }
    public decimal? ProductPrice { get; set; }   
}
