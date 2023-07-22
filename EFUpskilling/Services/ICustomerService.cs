using EFUpskilling.Entities;

namespace EFUpskilling.Services;

public interface ICustomerService
{
    Customer CreatNewCustomer(Customer customer);
    Customer GetById(string id);
}