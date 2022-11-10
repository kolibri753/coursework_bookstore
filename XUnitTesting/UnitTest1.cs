using Xunit;
using bookstore_mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;
using System.Net.Http;

namespace XUnitTesting;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
{
  private readonly WebApplicationFactory<Program> _factory;
  private readonly HttpClient httpClient;

  public UnitTest1(WebApplicationFactory<Program> factory)
  {
    _factory = factory;
    httpClient = _factory.CreateClient();
  }

  [Fact]
  public async void TestHomePage()
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync("/Home/Index");
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }

  [Theory]
  [InlineData("/Books")]
  [InlineData("/Books/Info/1")]
  [InlineData("/Books/Create")]
  [InlineData("/Books/Edit/1")]
  [InlineData("/Books/Delete/1")]
  public async Task TestBooksPages(string URL)
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync(URL);
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }

  [Theory]
  [InlineData("/Authors")]
  [InlineData("/Authors/Info/1")]
  [InlineData("/Authors/Create")]
  [InlineData("/Authors/Edit/1")]
  [InlineData("/Authors/Delete/1")]
  public async Task TestAuthorsPages(string URL)
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync(URL);
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }

  [Theory]
  [InlineData("/Publishers")]
  [InlineData("/Publishers/Info/1")]
  [InlineData("/Publishers/Create")]
  [InlineData("/Publishers/Edit/1")]
  [InlineData("/Publishers/Delete/1")]
  public async Task TestPublishersPages(string URL)
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync(URL);
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }

  [Theory]
  [InlineData("/Account")]
  [InlineData("/Account/Login")]
  [InlineData("/Account/Register")]
  // [InlineData("/Account/Logout")] //405
  public async Task TestAccountPages(string URL)
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync(URL);
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }

  [Theory]
  [InlineData("/Orders")]
  [InlineData("/Orders/ShoppingCart")]
  [InlineData("/Orders/AddItemToShoppingCart")]
  // [InlineData("/Orders/RemoveItemFromShoppingCart/1")] //400
  // [InlineData("/Orders/CompleteOrder")] //505
  public async Task TestOrdersPages(string URL)
  {
    var client = _factory.CreateClient();
    var response = await client.GetAsync(URL);
    int code = (int)response.StatusCode;

    Assert.Equal(200, code);
  }


  [Theory]
  [InlineData("Azkaban")]
  [InlineData("Harry Potter")]
  [InlineData("Game of Thrones")]
  public async Task TestForBooks(string title)
  {
    // var client = _factory.CreateClient();
    var response = await httpClient.GetAsync("/Books");
    var pageContent = await response.Content.ReadAsStringAsync();
    var contentString = pageContent.ToString();

    Assert.Contains(title, contentString);
  }
}