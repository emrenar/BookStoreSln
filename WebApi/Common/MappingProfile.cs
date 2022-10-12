using AutoMapper;
using WebApi.BookOperations.CreateBook;
using WebApi.BookOperations.GetBooks;

namespace WebApi.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>(); // (source,target)
            CreateMap<Book, BookViewModel>()
                .ForMember(dest=>dest.Genre, opt=>opt.MapFrom(src=>((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest=>dest.PublisDate,opt=>opt.MapFrom(src=>(src.PublishDate.Date.ToString("dd/MM/yyyy"))));
            CreateMap<Book, BooksViewModel>()
                .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()))
                .ForMember(dest => dest.PublisDate, opt => opt.MapFrom(src => (src.PublishDate.Date.ToString("dd/MM/yyyy"))));
        }
        
    }
}
