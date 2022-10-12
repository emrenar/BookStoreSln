using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
            var bookList = _dbContext.Books.OrderBy(x => x.Id).ToList<Book>();
            List<BooksViewModel> vm = new List<BooksViewModel>();
            foreach (var book in bookList)
            {
                vm.Add(new BooksViewModel()
                {
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Genre = ((GenreEnum)book.GenreId).ToString(),
                    PublisDate=book.PublishDate.Date.ToString("dd/MM/yyyy")
                    
                });
            }
            return vm;
        }
    }
    public class BooksViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublisDate { get; set; }

        public string Genre { get; set; }
    }
}
