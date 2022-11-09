using Xunit;
using bookstore_mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace XUnitTesting;

public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public UnitTest1(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async void Test1()
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync("/Home/Index");
        int code = (int)response.StatusCode;

        Assert.Equal(200, code);
    }

    [Theory]
    [InlineData("/Books/Create")]
    [InlineData("/Books/Edit/1")]
    public async Task TestAllPages(string URL)
    {
        var client = _factory.CreateClient();
        var response = await client.GetAsync(URL);
        int code = (int)response.StatusCode;

        Assert.Equal(200, code);
    }
}