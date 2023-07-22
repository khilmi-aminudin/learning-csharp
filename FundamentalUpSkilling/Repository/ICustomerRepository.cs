using FundamentalUpSkilling.Models;

namespace FundamentalUpSkilling.Repository;

public interface ICustomerRepository
{
    void GenerateTable();
    void Create(Customer customer);
    Customer? GetById(int id);
    List<Customer> GetAll();
    void Update(Customer customer);
    void Delete(int id);
}