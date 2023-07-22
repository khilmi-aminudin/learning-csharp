using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IPersistance _persistance;

    public ProductService(IRepository<Product> repository, IPersistance persistance)
    {
        _repository = repository;
        _persistance = persistance;
    }

    public Product CreateNewProduct(Product product)
    {
        try
        {
            var newProduct = _repository.Save(product);
            _persistance.SaveChanges();
            return newProduct;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Product GetById(string id)
    {
        try
        {
            var product = _repository.FindById(Guid.Parse(id));
            if (product == null) throw new Exception("Product not found");
            return product;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}