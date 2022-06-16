using ConverterAPI.Data;
using ConverterAPI.Services;

namespace ConverterTest.Test;

public class ConverterApiTest
{
    private readonly ConverterDbContext _context;
    private readonly CurrencyDbService _DbService;
    public ConverterApiTest(ConverterDbContext context
                            , CurrencyDbService dbService)
    {
        _context = context;
        _DbService = dbService;
    }

    [Fact]
    public void Test1()
    {
        // Arrange

        // Act

        // Assert

    }
}