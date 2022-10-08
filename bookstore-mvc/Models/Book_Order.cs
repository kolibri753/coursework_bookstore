namespace bookstore_mvc.Models
{
  public class Book_Order
  {
    public int BookId { get; set; }
    public Book? Book { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }
  }
}