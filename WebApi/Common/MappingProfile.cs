using AutoMapper;
using WebApi.Application.AuthorOperations.Commands.CreateAuthor;
using WebApi.Application.AuthorOperations.Commands.UpdateAuthor;
using WebApi.Application.AuthorOperations.Queries.GetAuthorDetails;
using WebApi.Application.AuthorOperations.Queries.GetAuthors;
using WebApi.Application.GenreOperations.Commands.CreateGenre;
using WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using WebApi.Application.GenreOperations.Queries.GetGenres;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //Book
            CreateMap<CreateBookModel, Book>(); // (source,target)

            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest=>dest.Author,opt=> opt.MapFrom(src=>src.Author.Name))
                .ForMember(dest=>dest.PublisDate,opt=>opt.MapFrom(src=>(src.PublishDate.Date.ToString("dd/MM/yyyy"))));

            CreateMap<Book, BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
                .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name))
                .ForMember(dest => dest.PublisDate, opt => opt.MapFrom(src => (src.PublishDate.Date.ToString("dd/MM/yyyy"))));

            // Genre
            CreateMap<Genre,GenresViewModel>();
            CreateMap<Genre,GenreDetailViewModel>();
            CreateMap<CreateGenreModel, Genre>();

            //Author
            CreateMap<Author, GetAuthorsViewModel>();
            CreateMap<Author,GetAuthorDetailViewModel>();
            CreateMap<CreateAuthorModel, Author>();  

           

        }

    }
}
