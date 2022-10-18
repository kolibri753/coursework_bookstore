using System.ComponentModel.DataAnnotations;

namespace bookstore_mvc.Data.Validation
{
  public class OnlyPositiveIntAttribute : ValidationAttribute
  {
    public override bool IsValid(object? value)
    {
      var x = (int?)value;
      return x > 0;
    }
  }
}