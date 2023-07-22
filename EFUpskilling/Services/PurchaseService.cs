using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class PurchaseService : IPurchaseService
{
    private readonly IRepository<Purchase> _repository;
    private readonly IPersistance _persistance;
    private readonly IProductService _productService;

    public PurchaseService(IRepository<Purchase> repository, IPersistance persistance, IProductService productService)
    {
        _repository = repository;
        _persistance = persistance;
        _productService = productService;
    }

    public Purchase CreateNewTransaction(Purchase purchase)
    {
        _persistance.BeginTransaction();
        try
        {
            var newPurchase = _repository.Save(purchase);
            _persistance.SaveChanges();
            
            foreach (var pd in newPurchase.PurchaseDetail)
            {
                Console.WriteLine(pd.ProductId.ToString());
                var product = _productService.GetById(pd.ProductId.ToString());
                product.Stock -= pd.Qty;
            }
            _persistance.SaveChanges();
            _persistance.Commit();

            return newPurchase;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _persistance.Rollback();
            throw;
        }
    }
}