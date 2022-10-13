using bookstore_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace bookstore_mvc.Data
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // modelBuilder.Entity<Book_Order>().HasKey(bo => new
      // {
      //   bo.OrderId,
      //   bo.BookId
      // });

      // modelBuilder.Entity<Book_Order>().HasOne(i => i.Book).WithMany(bo => bo.Books_Orders).HasForeignKey(i => i.BookId);
      // modelBuilder.Entity<Book_Order>().HasOne(i => i.Order).WithMany(bo => bo.Books_Orders).HasForeignKey(i => i.OrderId);

      // base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    // public DbSet<Customer> Customers { get; set; }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Book_Order> Books_Orders { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
  }
}