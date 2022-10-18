using System.ComponentModel.DataAnnotations;
using bookstore_mvc.Data.Base;

namespace bookstore_mvc.Models
{
  public class Author : IEntityBase
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "ImageURL")]
    [Required(ErrorMessage = "Missing Data")]
    public string ImageURL { get; set; } = string.Empty;

    [Display(Name = "Name")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Length must be beetween 2 and 200 chars")]
    [Required(ErrorMessage = "Missing Data")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "Biography")]
    [MinLength(10, ErrorMessage = "Length must be at least 10 characters long")]
    [Required(ErrorMessage = "Missing Data")]
    public string Biography { get; set; } = string.Empty;

    public List<Book>? Books { get; set; }
  }
}