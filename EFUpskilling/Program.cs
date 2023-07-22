using EFUpskilling.Services;
using Microsoft.EntityFrameworkCore;

namespace EFUpskilling;
using EFUpskilling.Repositories;
using EFUpskilling.Entities;
using System.Dynamic;

public class Program
{
    public static void Main()
    {
        AppDbContext context = new();
        IRepository<Purchase> purchaseRepository = new Repository<Purchase>(context);
        IRepository<Product> productRepository = new Repository<Product>(context);
        IPersistance persistance = new Persistance(context);
        IProductService productService = new ProductService(productRepository, persistance);
        IPurchaseService purchaseService = new PurchaseService(purchaseRepository, persistance, productService);

        var purchase = new Purchase
        {
            TransactionDate = DateTime.Now,
            CustomerId = Guid.Parse("b820feb2-6fbf-4b1c-bbe3-3ae2f1745139"),
            PurchaseDetail = new List<PurchaseDetail>
            {
                new()
                {
                    ProductId = Guid.Parse("00890c4a-694e-4352-abe0-e74c4d7ff031"),
                    Qty = 10,
                },
                new()
                {
                    ProductId = Guid.Parse("5c3273d3-50fb-4e7a-aa40-dd2ec7274462"),
                    Qty = 5,
                },
                new()
                {
                    ProductId = Guid.Parse("a152b9dc-85bd-401d-b9b7-03205a1b2f32"),
                    Qty = 5,
                },
            }
        };

        purchaseService.CreateNewTransaction(purchase);
        
        // var purchase = context.Purchases
        //     .Include( "Customer" )
        //     .Include( p => p.PurchaseDetail).ThenInclude( pd => pd.Product)
        //     .FirstOrDefault( p => p.Id.Equals(Guid.Parse("27989d78-8ef5-4fd1-b6db-e96008f79d1c")));
        // Console.WriteLine(purchase.Customer.ToString());

        // IRepository<Customer> repository = new Repository<Customer>(context);

        // var cst = new Customer{
        //     Name = "Customer one",
        //     Address = "Pemalang",
        //     PhoneNumber = "0623334567",
        //     Email = "customer@example.com",
        // };
        // repository.Save(cst);

        // var customer = repository.FindById(Guid.Parse("65386fdf-ed3b-4019-baff-4043c0ddae8e"));
        // Console.WriteLine(customer.ToString());
        //
        //
        // customer = repository.Find(_x => _x.Name.ToLower().Equals("customer one".ToLower()));
        // Console.WriteLine(customer.ToString());

        // IRepository<Product> productRepository = new Repository<Product>(context);
        // var products = new List<Product>()
        // {
        //     new Product
        //     {
        //         Name = "Hoodie",
        //         Price = 199000,
        //         Stock = 50
        //     },
        //     new Product
        //     {
        //         Name = "Jeans",
        //         Price = 299000,
        //         Stock = 100
        //     },
        //     new Product
        //     {
        //         Name = "T-Shirt",
        //         Price = 150000,
        //         Stock = 200
        //     }
        // };
        //
        // products.ForEach(p => productRepository.Save(p));


    }
}
        // var dbTransactions = context.Database.BeginTransaction();
        // try
        // {
        //     var purchase = new Purchase
        //     {
        //         TransactionDate = DateTime.Now,
        //         // CustomerId = Guid.Parse("65386fdf-ed3b-4019-baff-4043c0ddae8e"),
        //         Customer = new Customer
        //         {
        //             Name = "Khilmi Aminudin",
        //             Address = "Pemalang",
        //             PhoneNumber = "082339451638",
        //             Email = "khilmiaminudin715@gmail.com"
        //         },
        //         PurchaseDetail = new List<PurchaseDetail>
        //         {
        //             new() { ProductId = Guid.Parse("5c3273d3-50fb-4e7a-aa40-dd2ec7274462"), Qty = 2 },
        //             new() { ProductId = Guid.Parse("a152b9dc-85bd-401d-b9b7-03205a1b2f32"), Qty = 2 }
        //         }
        //     };
        //     context.Purchases.Add(purchase);
        //     context.SaveChanges();
        //
        //     foreach (var purchaseDetail in  purchase.PurchaseDetail)
        //     {
        //         var product = context.Products.FirstOrDefault(p => p.Id.Equals(purchaseDetail.ProductId));
        //         if (product != null) product.Stock -= purchaseDetail.Qty;
        //     }
        //
        //     context.SaveChanges();
        //     
        //     context.SaveChanges();
        //    
        //     dbTransactions.Commit();
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e);
        //     dbTransactions.Rollback();
        //     throw;
        // }


        // using AppDbContext context = new();

        // // INSERT ONE
        // var customer = new Customer{
        //     Name = "Lorem Ipsum",
        //     Address = "Pemalang",
        //     PhoneNumber = "092763823682746",
        //     Email = "lorem@ipsum.com"
        // };
        // context.Customers.Add(customer);
        // Console.WriteLine(context.Entry(customer).State);

        // // INSERT BATCH
        // context.Customers.AddRange(new List<Customer>{
        //     new Customer{
        //         Name = "Lorem Ipsum",
        //         Address = "Pemalang",
        //         PhoneNumber = "09276382368",
        //         Email = "lorem@ipsum.com"
        //     },
        //     new Customer{
        //         Name = "Lorem Ode",
        //         Address = "Tegal",
        //         PhoneNumber = "063823682746",
        //         Email = "ode@ipsum.com"
        //     },
        //     new Customer{
        //         Name = "Rani Brina",
        //         Address = "Pekalongan",
        //         PhoneNumber = "0812123123",
        //         Email = "brina@rani.com"
        //     },
        // });
        // context.SaveChanges();
        // Console.WriteLine(context.Entry(customers).State);

        // // GET ONE
        // var customer = context.Customers.FirstOrDefault( c => c.Id.Equals(1));
        // Console.WriteLine(
        //     $"Customer: id : {customer.Id}, Name : {customer.Name}, Email : {customer.Email}, Phone : {customer.PhoneNumber} Address : {customer.Address}"
        // );
        // Console.WriteLine(context.Entry(customer).State);
        
        // var customer = context.Customers.FirstOrDefault( c => string.Equals(c.Name.ToLower(), "jhon doe".ToLower()));
        // Console.WriteLine(
        //     $"Customer: id : {customer.Id}, Name : {customer.Name}, Email : {customer.Email}, Phone : {customer.PhoneNumber} Address : {customer.Address}"
        // );
        // Console.WriteLine(context.Entry(customer).State);

        
        // // LIST ALL
        // var customers = context.Customers.ToList();
        // customers.ForEach( _x => Console.WriteLine(_x.ToString()));

        // // UPDATE
        // var customer = context.Customers.FirstOrDefault( c => c.Id.Equals(1));
        // Console.WriteLine(
        //     $"Customer: id : {customer.Id}, Name : {customer.Name}, Email : {customer.Email}, Phone : {customer.PhoneNumber} Address : {customer.Address}"
        // );
        // Console.WriteLine(context.Entry(customer).State);
        // customer.Name = "Khilmi Aminudin";
        // context.Customers.Update(customer);
        // context.SaveChanges();
        // Console.WriteLine(context.Entry(customer).State);

        
        // DELETE
        // var customer = context.Customers.FirstOrDefault( c => c.Id.Equals(4));
        // Console.WriteLine(
        //     $"Customer: id : {customer.Id}, Name : {customer.Name}, Email : {customer.Email}, Phone : {customer.PhoneNumber} Address : {customer.Address}"
        // );
        // Console.WriteLine(context.Entry(customer).State);
        // context.Customers.Remove(customer);
        // context.SaveChanges();
        // Console.WriteLine(context.Entry(customer).State);

// 2023-01-16 37:00