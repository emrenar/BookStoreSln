using Microsoft.EntityFrameworkCore;

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

                context.Books.AddRange(new Book
                {
                    //Id = 1,
                    Title = "Lean Startup",
                    GenreId = 1,//Personel Growth
                    PageCount = 200,
                    PublishDate = new DateTime(2011, 06, 18)
                },
              new Book
             {
                 //Id = 2,
                 Title = "Herland",
                 GenreId = 2,//Science Fiction
                 PageCount = 250,
                 PublishDate = new DateTime(2010, 05, 23)
             },
              new Book
              {
                  //Id = 3,
                  Title = "Lean Startup",
                  GenreId = 2,//Science Fiction
                  PageCount = 540,
                  PublishDate = new DateTime(2001, 03, 08)
              });

                context.SaveChanges();
            }


        }
    }
}


