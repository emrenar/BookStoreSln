using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
                    new Author { BirthDate = new DateTime(1997, 10, 10), Name = "George Orwell" },
                    new Author { BirthDate = new DateTime(1978, 5, 5), Name = "J.K Rowling" },
                    new Author { BirthDate = new DateTime(1990, 7, 25), Name = "Robert Greene" },
                    new Author { BirthDate = new DateTime(1958, 8, 5), Name = "Dan Brown" }
                    );
        }
    }
}
