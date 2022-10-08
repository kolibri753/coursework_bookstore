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

        if (!context.Authors.Any())
        {
          context.Authors.AddRange(new List<Author>()
          {
            new Author()
            {
              ImageURL = "/img/authors/JKRowling.jpg",
              Name = "J. K. Rowling",
              Biography = "Joanne Rowling CH OBE FRSL (born 31 July 1965), also known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote Harry Potter, a seven-volume children's fantasy series published from 1997 to 2007. The series has sold over 500 million copies, been translated into at least 70 languages, and spawned a global media franchise including films and video games. The Casual Vacancy (2012) was her first novel for adults. She writes Cormoran Strike, an ongoing crime fiction series, as Robert Galbraith."
            },
            new Author()
            {
              ImageURL = "/img/authors/GeorgeRRMartin.jpg",
              Name = "George R. R. Martin",
              Biography = "George Raymond Richard Martin (born September 20, 1948), also known as GRRM, is an American novelist, screenwriter, television producer and short story writer. He is the author of the series of epic fantasy novels A Song of Ice and Fire, which were adapted into the Emmy Award-winning HBO series Game of Thrones (2011-2019). He also helped create the Wild Cards anthology series, and contributed worldbuilding for the 2022 video game Elden Ring."
            },

          });
          context.SaveChanges();
        }

        if (!context.Publishers.Any())
        {
          context.Publishers.AddRange(new List<Publisher>()
          {
            new Publisher()
            {
              ImageURL = "/img/publishers/bloomsbury.png",
              Name = "Bloomsbury",
              Biography = "Bloomsbury Publishing plc is a British worldwide publishing house of fiction and non-fiction. It is a constituent of the FTSE SmallCap Index. Bloomsbury's head office is located in Bloomsbury, an area of the London Borough of Camden. It has a US publishing office located in New York City, an India publishing office in New Delhi, an Australia sales office in Sydney CBD and other publishing offices in the UK including in Oxford. The company's growth over the past two decades is primarily attributable to the Harry Potter series by J. K. Rowling and, from 2008, to the development of its academic and professional publishing division."
            },
            new Publisher()
            {
              ImageURL = "/img/publishers/doubleday.png",
              Name = "Doubleday",
              Biography = "Doubleday is an American publishing company. It was founded as the Doubleday & McClure Company in 1897 and was the largest in the United States by 1947. It published the work of mostly U.S. authors under a number of imprints and distributed them through its own stores. In 2009 Doubleday merged with Knopf Publishing Group to form the Knopf Doubleday Publishing Group, which is now part of Penguin Random House. In 2019, the official website presents Doubleday as an imprint, not a publisher."
            },

          });
          context.SaveChanges();
        }

        if (!context.Books.Any())
        {
          context.Books.AddRange(new List<Book>()
          {
            new Book()
            {
              ImageURL = "/img/books/GameOfThrones.jpg",
              Title = "A Game of Thrones",
              Pages = 694,
              Price = 610,
              Quantity = 100,
              Genre = Genre.Fantasy,
              AuthorId = 2,
              PublisherId = 2
            },
            new Book()
            {
              ImageURL = "/img/books/HarryPotterAndTheChamberOfSecrets.jpg",
              Title = "Harry Potter and the Philosopher's Stone",
              Pages = 223,
              Price = 250,
              Quantity = 100,
              Genre = Genre.Adventure,
              AuthorId = 1,
              PublisherId = 1
            },
            new Book()
            {
              ImageURL = "/img/books/HarryPotterAndThePhilosophersStone.jpg",
              Title = "Harry Potter and the Chamber of Secrets",
              Pages = 251,
              Price = 260,
              Quantity = 100,
              Genre = Genre.Adventure,
              AuthorId = 1,
              PublisherId = 1
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