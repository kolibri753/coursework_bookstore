using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bookstore_mvc.Models
{
  public class Book_Order
  {
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }
    public double Price { get; set; }

    public int BookId { get; set; }
    [ForeignKey("BookId")]
    public Book? Book { get; set; }

    public int OrderId { get; set; }
    [ForeignKey("OrderId")]
    public Order? Order { get; set; }
  }
}