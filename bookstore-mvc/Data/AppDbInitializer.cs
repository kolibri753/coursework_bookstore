using bookstore_mvc.Models;

namespace bookstore_mvc.Data
{
  public class AppDbInitializer
  {
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
      using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

        context.Database.EnsureCreated();
        
        if (!context.Books.Any())
        {
          context.Books.AddRange(new List<Book>()
          {
            new Book()
            {
              ImageURL = "/img/GameOfThrones.jpg",
              Title = "A Game of Thrones",
              Pages = 694,
              Price = 610,
              Quantity = 100,
              Genre = Genre.Fantasy,
              Author = Author.GeorgeRRMartin
            },
            new Book()
            {
              ImageURL = "/img/HarryPotterAndTheChamberOfSecrets.jpg",
              Title = "Harry Potter and the Philosopher's Stone",
              Pages = 223,
              Price = 250,
              Quantity = 100,
              Genre = Genre.Adventure,
              Author = Author.JKRowling
            },
            new Book()
            {
              ImageURL = "/img/HarryPotterAndThePhilosophersStone.jpg",
              Title = "Harry Potter and the Chamber of Secrets",
              Pages = 251,
              Price = 260,
              Quantity = 100,
              Genre = Genre.Adventure,
              Author = Author.JKRowling
            },
          });
          context.SaveChanges();
        }

        if (!context.Customers.Any())
        {
          context.Customers.AddRange(new List<Customer>()
          {
            new Customer()
            {
              Name = "Vira",
              Phone = "123 123 1234",
              Email = "vahovskavm2003@gmail.com",
              Address = "Ukraine, Khmelnitskyi",
              Username = "vira",
              Password = "1234"
            },
            new Customer()
            {
              Name = "Petya",
              Phone = "123 123 1234",
              Email = "petya@gmail.com",
              Address = "Ukraine, Khmelnitskyi",
              Username = "petya",
              Password = "1234"
            },
            new Customer()
            {
              Name = "Vanya",
              Phone = "123 123 1234",
              Email = "vanya@gmail.com",
              Address = "Ukraine, Khmelnitskyi",
              Username = "vanya",
              Password = "1234"
            },
          });
          context.SaveChanges();
        }

      }
    }
  }
}