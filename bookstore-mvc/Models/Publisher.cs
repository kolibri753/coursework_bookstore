using System.ComponentModel.DataAnnotations;
using bookstore_mvc.Data.Base;

namespace bookstore_mvc.Models
{
  public class Publisher : IEntityBase
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "ImageURL")]
    [Required(ErrorMessage = "Missing Data")]
    public string ImageURL { get; set; } = string.Empty;

    [Display(Name = "Name")]
    [Required(ErrorMessage = "Missing Data")]
    public string Name { get; set; } = string.Empty;

    [Display(Name = "About")]
    [Required(ErrorMessage = "Missing Data")]
    public string About { get; set; } = string.Empty;

    public List<Book>? Books { get; set; }
  }
}