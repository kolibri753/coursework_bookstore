// using System;
// using System.Collections.Generic;
// using System.ComponentModel.DataAnnotations;
// using System.Linq;
// using System.Threading.Tasks;

// namespace bookstore_mvc.Models
// {
//     public class Customer
//     {
//         [Key]
//         public int Id { get; set; }

//         public string Name { get; set; }  = string.Empty;
//         public string Phone { get; set; }  = string.Empty;
//         public string Email { get; set; }  = string.Empty;
//         public string Address { get; set; }  = string.Empty;
//         public string Username { get; set; }  = string.Empty;
//         public string Password { get; set; }  = string.Empty;

//         public List<Order>? Orders { get; set; }
//     }
// }