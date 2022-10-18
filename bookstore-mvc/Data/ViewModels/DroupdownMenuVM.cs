using bookstore_mvc.Models;

namespace bookstore_mvc.Data.ViewModels
{
  public class BookDroupdownMenuVM
  {
    public BookDroupdownMenuVM()
    {
        Authors = new List<Author>();
        Publishers = new List<Publisher>();
    }

    public List<Author> Authors { get; set; }
    public List<Publisher> Publishers { get; set; }
  }
}