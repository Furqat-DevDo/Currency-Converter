using ConverterAPI.Data;
using ConverterAPI.Services;
using CurrencyConverter.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ConverterDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ICurrencyService, CurrencyDbService>();
builder.Services.AddScoped<ICurrencyService, CurrencyDbService>();
builder.Services.AddTransient<ICountryService, CountryDbService>();
builder.Services.AddScoped<ICountryService, CountryDbService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
