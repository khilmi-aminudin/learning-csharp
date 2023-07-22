using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name: "m_product")]
public class Product
{
    [Key, Column(name: "id")]
    public Guid Id { get; set;}

    [Column(name: "name", TypeName = "VARCHAR(100)")]
    public string Name { get; set;}

    [Column(name: "price", TypeName = "NUMERIC(10,2)")]
    public long Price { get; set;}

    [Column(name: "stock", TypeName = "INT")]
    public int Stock { get; set;}

    public override string ToString()
    {
        return $"[Id : {Id}, Name : {Name}, Price : {Price}, Stock : {Stock}]";
    }

}