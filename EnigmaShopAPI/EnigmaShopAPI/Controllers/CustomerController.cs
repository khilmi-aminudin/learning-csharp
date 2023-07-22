using EnigmaShopAPI.Entities;
using EnigmaShopAPI.Models.WebResponse;
using EnigmaShopAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EnigmaShopAPI.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    private readonly IRepository<Customer> _customerrepository;
    private readonly IPersistance _persistance;

    public CustomerController(IRepository<Customer> customerrepository, IPersistance persistance)
    {
        _customerrepository = customerrepository;
        _persistance = persistance;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] Customer payload)
    {
        try
        {
            var customer = await _customerrepository.SaveAsync(payload);
            await _persistance.SaveChangesAsync();
            return Created("/api/customers", customer);
        } catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(string id)
    {
        try
        {
            var customer = await _customerrepository.FindByIdAsync(Guid.Parse(id));
            
            var rsp = new WebResponse
            {
                Code = 404,
                Message = "Not Found",
                Data = $"customer with id {id} not found"
            };
            
            if (customer == null) return NotFound(rsp);
            
            
            rsp = new WebResponse
            {
                Code = 200,
                Message = "Success",
                Data = customer
            };
            
            return Ok(rsp);
        } catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllCustomer()
    {
        try
        {
            var customers = await _customerrepository.FindAllAsync();
            var rsp = new WebResponse
            {
                Code = 200,
                Message = "Success",
                Data = customers
            };
            
            return Ok(rsp);
        } catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateCustomer([FromBody] Customer payload) 
    {
        try
        {
            var customer = _customerrepository.Update(payload);
            await _persistance.SaveChangesAsync();
            return Ok(customer);
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCustomer(string id)
    {
        try
        {
            var customer = await _customerrepository.FindByIdAsync(Guid.Parse(id));
            if (customer == null) return NotFound("customer not found");
            _customerrepository.Delete(customer);
            await _persistance.SaveChangesAsync();
            return Ok();
        }
        catch (Exception e)
        {
            return new StatusCodeResult(500);
        }
    }
}