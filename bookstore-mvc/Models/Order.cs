using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookstore_mvc.Models
{
  public class Order
  {
    [Key]
    public int Id { get; set; }

    // public double TotalPrice { get; set; }
    // public DateTime StartDate { get; set; }
    public string Email { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    // [ForeignKey("CustomerId")]
    // public Customer? Customer { get; set; }

    public List<Book_Order>? Books_Orders { get; set; }
  }
}