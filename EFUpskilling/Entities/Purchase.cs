using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFUpskilling.Entities;

[Table(name: "t_purchase")]
public class Purchase
{
    [Key, Column(name: "id")]
    public Guid Id { get; set;}
    
    [Column(name: "transaction_date", TypeName = "TIMESTAMP")]
    public DateTime TransactionDate { get; set;}

    [Column(name: "customer_id")]
    public Guid CustomerId { get; set;}

    public virtual Customer Customer { get; set;}
    public virtual ICollection<PurchaseDetail> PurchaseDetail{ get; set; }

    public override string ToString()
    {
        return $"[Id : {Id}, TransactionDate : {TransactionDate}, CustomerId : {CustomerId}]";
    }

}