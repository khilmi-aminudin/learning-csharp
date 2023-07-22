using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name: "m_customer")]
public class Customer
{
    [Key, Column(name: "id")]
    public Guid Id { get; set; }
    
    [Column(name: "name", TypeName = "VARCHAR(100)")]
    public string Name { get; set; }
    
    [Column(name: "address", TypeName = "VARCHAR(200)")]
    public string Address { get; set; }
    
    [Column(name: "phone_number", TypeName = "VARCHAR(13)")]
    public string PhoneNumber { get; set; }
    
    [Column(name: "email", TypeName = "VARCHAR(100)")]
    public string Email { get; set; }

    public override string ToString()
    {
        return $"[Id : {Id}, Name : {Name}, Address : {Address}, PhoneNumber : {PhoneNumber}, Email : {Email}]";
    }
}