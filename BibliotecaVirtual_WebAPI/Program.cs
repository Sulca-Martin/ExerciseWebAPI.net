using BibliotecaVirtual_DataAccessLayer.Data;
using BibliotecaVirtual_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BibliotecaVirtualDbContext>
    (
        options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BibliotecaVirtualDbContext>();
    //context.Database.Migrate();       // Nos aseguramos de que cada vez que corra el sistema, se añade migraciones

    SeedData.Initialize(context);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class SeedData
{
    public static void Initialize(BibliotecaVirtualDbContext context)
    {
        if (!context.Users.Any())
        {
            context.Add(new User()
            {
                Name = "prueba",
                LastName = "pruebaa",
                Docket = 1234,
                Email = "prueba@email.com",
                Password = "Password",
            });
            context.SaveChanges();
        }

        if (!context.Authors.Any())
        {
            context.Authors.AddRange(
                new Author
                {
                    Name = "Allan"
                },
                new Author
                {
                    Name = "Paulo"
                },
                new Author
                {
                    Name = "Jane"
                }
            );
            context.SaveChanges();
        }

        if (!context.Categorys.Any())
        {
            context.Categorys.AddRange(
                new Category
                {
                    Name = "Accion"
                },
                new Category
                {
                    Name = "Drama"
                },
                new Category
                {
                    Name = "Terror"
                }
            );
            context.SaveChanges();
        }

        if (!context.Books.Any())
        {
            context.Books.AddRange(
                new Book
                {
                    Title = "Alice 123",
                    AuthorId = 1,
                    CategoryId = 1,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 8, 15)
                },
                new Book
                {
                    Title = "Bob 456",
                    AuthorId = 1,
                    CategoryId = 1,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 7, 22)
                },
                new Book
                {
                    Title = "Charlie 789",
                    AuthorId = 3,
                    CategoryId = 1,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 5, 30)
                },
                new Book
                {
                    Title = "David 101",
                    AuthorId = 1,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2022, 12, 25)
                },
                new Book
                {
                    Title = "Eve 202",
                    AuthorId = 2,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 3, 17)
                },
                new Book
                {
                    Title = "Faythe 303",
                    AuthorId = 3,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2022, 11, 11)
                },
                new Book
                {
                    Title = "Grace 404",
                    AuthorId = 2,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 1, 8)
                },
                new Book
                {
                    Title = "Heidi 505",
                    AuthorId = 2,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2022, 10, 5)
                },
                new Book
                {
                    Title = "Ivan 606",
                    AuthorId = 2,
                    CategoryId = 2,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 4, 20)
                },
                new Book
                {
                    Title = "Judy 707",
                    AuthorId = 3,
                    CategoryId = 3,
                    Amount = 100,
                    PublicationDate = new DateTime(2023, 2, 14)
                }
            );

            context.SaveChanges();
        }

        if (!context.Loans.Any())
        {
            context.Loans.AddRange(
                new Loan
                {
                    LoanNumber = "1",
                    LoanDate = new DateTime(2024, 8,31)
                },
                new Loan
                {
                    LoanNumber = "2",
                    LoanDate = new DateTime(2024, 9, 1)
                },
                new Loan
                {
                    LoanNumber = "3",
                    LoanDate = new DateTime(2024, 9, 5)
                }
            );
        }
    }
}