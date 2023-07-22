namespace DapperFundamental.Models;

public class Product
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public double ProductPrice { get; set; }
    public int Stock { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Product product &&
               Id == product.Id &&
               ProductName == product.ProductName &&
               ProductPrice == product.ProductPrice &&
               Stock == product.Stock;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, ProductName, ProductPrice, Stock);
    }

    public override string ToString()
    {
        return $"[\n  id : {Id},\n  product_name : {ProductName},\n  product_price : {ProductPrice},\n  stock : {Stock}\n], ";
    }
}