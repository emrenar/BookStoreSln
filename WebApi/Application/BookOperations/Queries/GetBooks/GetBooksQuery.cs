using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Common;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetBooksQuery(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.Include(x=>x.Genre).Include(y=>y.Author).OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = _mapper.Map<List<BooksViewModel>>(bookList);//new List<BooksViewModel>();
            //foreach (var book in bookList)
            //{
            //    vm.Add(new BooksViewModel()
            //    {
            //        Title = book.Title,
            //        PageCount = book.PageCount,
            //        Genre = ((GenreEnum)book.GenreId).ToString(),
            //        PublisDate=book.PublishDate.Date.ToString("dd/MM/yyyy")
                    
            //    });
            //}
            return vm;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublisDate { get; set; }

        public string Genre { get; set; }

        public string Author { get; set; }
    }
}
