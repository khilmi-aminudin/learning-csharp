using EFUpskilling.Entities;
using EFUpskilling.Repositories;

namespace EFUpskilling.Services;

public class CustomerService : ICustomerService
{
    private readonly IRepository<Customer> _repository;
    private readonly IPersistance _persistance;

    public CustomerService(IRepository<Customer> repository, IPersistance persistance)
    {
        _repository = repository;
        _persistance = persistance;
    }

    public Customer CreatNewCustomer(Customer customer)
    {
        try
        {
            var newCustomer = _repository.Save(customer);
            _persistance.SaveChanges();
            return newCustomer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Customer GetById(string id)
    {
        try
        {
            var customer = _repository.FindById(Guid.Parse(id));
            if (customer != null) throw new Exception("Customer not found");
            return customer;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}