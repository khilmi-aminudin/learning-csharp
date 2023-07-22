using System.Data;
using Dapper;
using DapperFundamental.Config;
using DapperFundamental.Models;
using Npgsql.Replication;

namespace DapperFundamental;

public class Program
{
    public static void Main()
    {
        // var numbers = new List<int>{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

        // var query =
        //     from number in numbers // initalitation
        //     where number > 10 && number < 16 // condition
        //     select number; // selection

        // query.ToList().ForEach(i => Console.WriteLine(i));

        // var filtered = numbers.Where(x => x % 2 != 0).ToList();

        // Console.WriteLine(filtered.Count);

        // filtered.ForEach(x => Console.WriteLine(x));

        var products = new List<Product>{
            new() {Id = 1, ProductName = "Hoodie", ProductPrice = 150000, Stock = 200},
            new() {Id = 2, ProductName = "Flanel", ProductPrice = 120000, Stock = 150},
            new() {Id = 3, ProductName = "JeansX", ProductPrice = 399000, Stock = 100},
            new() {Id = 4, ProductName = "TShirt", ProductPrice = 165000, Stock = 455},
            new() {Id = 5, ProductName = "Belt-X", ProductPrice = 700000, Stock = 99},
            new() {Id = 6, ProductName = "Hoodie", ProductPrice = 150000, Stock = 200},
            new() {Id = 3, ProductName = "Flanel", ProductPrice = 120000, Stock = 150},
            new() {Id = 8, ProductName = "JeansX", ProductPrice = 399000, Stock = 100},
            new() {Id = 9, ProductName = "TShirt", ProductPrice = 165000, Stock = 455},
            new() {Id = 10, ProductName = "Belt-X", ProductPrice = 700000, Stock = 99},
            new() {Id = 11, ProductName = "Hoodie", ProductPrice = 150000, Stock = 200},
            new() {Id = 12, ProductName = "Flanel", ProductPrice = 120000, Stock = 150},
            new() {Id = 13, ProductName = "JeansX", ProductPrice = 399000, Stock = 100},
            new() {Id = 14, ProductName = "TShirt", ProductPrice = 165000, Stock = 455},
            new() {Id = 15, ProductName = "Belt-X", ProductPrice = 700000, Stock = 99},
            new() {Id = 16, ProductName = "Hoodie", ProductPrice = 150000, Stock = 200},
            new() {Id = 13, ProductName = "Flanel", ProductPrice = 120000, Stock = 150},
            new() {Id = 18, ProductName = "JeansX", ProductPrice = 399000, Stock = 100},
            new() {Id = 19, ProductName = "TShirt", ProductPrice = 165000, Stock = 455},
            new() {Id = 20, ProductName = "Belt-X", ProductPrice = 700000, Stock = 99},
        };

        // var filtered = products.Where(x => x.ProductPrice > 120000).Select( x => new { x.ProductName, x.Stock } ).Distinct().ToList();

        // filtered.ForEach(x => Console.WriteLine(x));
        int size = 5;
        int page = 1;
        var filtered = products.Where( i => i.ProductPrice > 120000).Skip((page - 1) * size).Take(5).Select( i => new { i.ProductName, i.ProductPrice} ).ToList();

        filtered.ForEach(i => Console.WriteLine(i));

        var a = 10;
        
        Console.WriteLine(a.Plus(10));




















        // DAPPER
        // ===============================================
        
        
        // using var connection = DbConfig.GetInstance().GetConnection();
        // DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        // // Example SELECT query using Dapper
        // string sqlQuery = "SELECT * FROM m_customer;";
        // var customers = connection.Query<Customer>(sqlQuery).ToList();

        // foreach (var customer in customers)
        // {
        //     Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Phone Number: {customer.PhoneNumber}");
        // }

        // // Example INSERT query using Dapper
        // string insertQuery = "INSERT INTO m_customer (name, phone_number) VALUES (@Name, @PhoneNumber);";
        // int rowsAffected = connection.Execute(insertQuery, new { Name = "John Doe", PhoneNumber = "1234567890" });

        // Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");

        //             // Example SELECT query using Dapper
        // sqlQuery = "SELECT * FROM m_customer;";
        // customers = connection.Query<Customer>(sqlQuery).ToList();

        // foreach (var customer in customers)
        // {
        //     Console.WriteLine($"Id: {customer.Id}, Name: {customer.Name}, Phone Number: {customer.PhoneNumber}");
        // }

        // var sql = @"
        // CREATE TABLE m_product (
        //     id BIGSERIAL,
        //     product_name VARCHAR(255) NOT NULL,
        //     product_price NUMERIC(10,2),
        //     stock BIGINT
        // );
        // ";

        // var sql = "INSERT INTO m_product (product_name, product_price, stock) VALUES ('sabun', 5000, 20),('shampo', 18000, 20)";

        // connection.Execute(sql);

        // var sql =  "SELECT * FROM m_product;";

        // var products = connection.Query<Product>(sql).ToList();

        // foreach (var item in products)
        // {
        //     Console.WriteLine(item.ToString());
        // }

        // var sql = "SELECT * FROM m_product WHERE id =1;";

        // var product = connection.QuerySingle<Product>(sql);
        // Console.WriteLine(product.ToString());

        // var sql = "SELECT COUNT(id) FROM m_product";
        // var count = connection.ExecuteScalar<int>(sql);
        // Console.WriteLine(count);

        // var products = new List<Product>
        // {
        //     new Product{
        //         ProductName = "Laptop",
        //         ProductPrice = 15000000,
        //         Stock = 10,
        //     },
        //     new Product{
        //         ProductName = "Mouse",
        //         ProductPrice = 150000,
        //         Stock = 100,
        //     },
        //     new Product{
        //         ProductName = "Adapter",
        //         ProductPrice = 200000,
        //         Stock = 50,
        //     },
        //     new Product{
        //         ProductName = "Earphone",
        //         ProductPrice = 399000,
        //         Stock = 55,
        //     },
        //     new Product{
        //         ProductName = "Headphone",
        //         ProductPrice = 799000,
        //         Stock = 60,
        //     },
        // };

        // var sql = @"INSERT INTO m_product (product_name, product_price, stock) VALUES (@ProductName, @ProductPrice, @Stock);";

        // foreach (var p in products)
        // {
        //     connection.Execute(sql, p);
        // }

        // var dynamicParameter = new DynamicParameters(products[0]);

        // connection.Execute(sql, dynamicParameter);

        // var sql = @"SELECT * FROM m_product WHERE product_price > @ProductPrice";
        // var products = connection.Query<Product>(sql, new {
        //     ProductPrice = 1000000
        // }).ToList();

        // products.ForEach(x => Console.WriteLine(x.ToString()));
    }
}


public static class MyExtension 
{
    public static int Plus(this int value, int parameter)
    {
        return value + parameter;
    }
}