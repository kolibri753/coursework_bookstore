using System.ComponentModel.DataAnnotations;
using bookstore_mvc.Data;
using bookstore_mvc.Data.Base;

namespace bookstore_mvc.Models
{
  public class NewBookVM
  {
    public int Id { get; set; }

    [Display(Name = "ImageURL")]
    [Required(ErrorMessage = "Missing Data")]
    public string ImageURL { get; set; } = string.Empty;

    [Display(Name = "Title")]
    [Required(ErrorMessage = "Missing Data")]
    [StringLength(265, MinimumLength = 2, ErrorMessage = "Title must be beetween 2 and 265 chars")]
    public string Title { get; set; } = string.Empty;

    [Display(Name = "Pages")]
    [Required(ErrorMessage = "Missing Data")]
    public int Pages { get; set; }

    [Display(Name = "Price")]
    [Required(ErrorMessage = "Missing Data")]
    public double Price { get; set; }

    [Display(Name = "Quantity")]
    [Required(ErrorMessage = "Missing Data")]
    public int Quantity { get; set; }

    [Display(Name = "Genre")]
    [Required(ErrorMessage = "Missing Data")]
    public Genre Genre { get; set; }

    [Display(Name = "Author")]
    [Required(ErrorMessage = "Missing Data")]
    public int AuthorId { get; set; }

    [Display(Name = "Publisher")]
    [Required(ErrorMessage = "Missing Data")]
    public int PublisherId { get; set; }

    public List<Book>? Books { get; set; }
  }
}