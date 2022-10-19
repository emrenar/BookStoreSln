using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
             new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1,//Personel Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2011, 06, 18),
                        AuthorId = 1
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
        }
    }
}
