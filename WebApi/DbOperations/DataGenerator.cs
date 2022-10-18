using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Authors.AddRange(
                    new Author { BirthDate = new DateTime(1997, 10, 10), Name = "George Orwell"},
                    new Author { BirthDate = new DateTime(1978,5,5), Name = "J.K Rowling" },
                    new Author { BirthDate = new DateTime(1990,7,25), Name = "Robert Greene"},                                                    
                    new Author { BirthDate = new DateTime(1958,8,5), Name = "Dan Brown"}                 
                    );

                context.Genres.AddRange(
                    new Genre {  Name = "Personel Growth" },
                    new Genre {  Name = "Science Fiction" },
                    new Genre { Name = "Romance" }
                    );

                context.Books.AddRange(
                    new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,//Personel Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2011, 06, 18),
                    AuthorId=1
                },
              new Book
             {
                 //Id = 2,
                 Title = "Herland",
                 GenreId = 2,//Science Fiction
                 PageCount = 250,
                 PublishDate = new DateTime(2010, 05, 23),
                 AuthorId = 2

              },
              new Book
              {
                  //Id = 3,
                  Title = "Lean Startup",
                  GenreId = 2,//Science Fiction
                  PageCount = 540,
                  PublishDate = new DateTime(2001, 03, 08),
                  AuthorId = 3

              },
              new Book
              {
                  
                  Title = "Atomic Habits",
                  GenreId = 1,
                  PageCount = 250,
                  PublishDate = new DateTime(2001, 03, 08),
                  AuthorId = 4

              });

                context.SaveChanges();
            }


        }
    }
}


