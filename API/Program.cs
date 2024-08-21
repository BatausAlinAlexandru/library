using LibraryApplication.API.Repository;
using LibraryApplication.API.Service.BookService;
using LibraryApplication.API.Service.LibraryService;
using LibraryApplication.API.Service.UserService;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Add DbContext with connection string


builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=LibraryDB;Integrated Security=True;Trust Server Certificate=True"));

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<BookRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<BookService>();  

builder.Services.AddScoped<LibraryService>();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
