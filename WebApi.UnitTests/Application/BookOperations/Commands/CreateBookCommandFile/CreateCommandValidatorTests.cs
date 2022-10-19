using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.BookOperations.CreateBook;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperations.Commands.CreateBookCommandFile
{
    public class CreateCommandValidatorTests
    {
        [Theory]
        [InlineData("Lord OF The Rings",0,0)]
        [InlineData("Lord OF The Rings",0,1)]
        [InlineData("L",0,0)]
        public void WhenInvalidInputAreGiven_Validator_ShouldBeReturnErrors(string title,int pageCount,int genreId)
        {
            // arrange
            CreateBookCommand command = new CreateBookCommand(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId,
                AuthorId = 2
            };
            //act
            CreateBookCommandValidator validator = new CreateBookCommandValidator();
            var result = validator.Validate(command);

            // assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
