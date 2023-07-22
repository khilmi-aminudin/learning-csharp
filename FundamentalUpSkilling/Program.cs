using FundamentalUpSkilling.Models;
using FundamentalUpSkilling.Repository;
using Npgsql;

namespace FundamentalUpSkilling;

public class Program
{
    public static void Main()
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        // customerRepository.GenerateTable();
        // customerRepository.Create(new Customer(){
        //     Name = "Dewi Febriyani",
        //     PhoneNumber = "12345678910"
        // });
        // customerRepository.Create(new Customer(){
        //     Name = "Khilmi Aminudin",
        //     PhoneNumber = "12345678910",
        //     IsActive = true
        // });

        var customers = customerRepository.GetAll();
        customers.ForEach(c => {
            Console.WriteLine($"[id: {c.Id}], name: {c.Name}, phone_number: {c.PhoneNumber}, isActive: {c.IsActive}");
        });
    }
}