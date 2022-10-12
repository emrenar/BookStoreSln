using WebApi.Common;
using WebApi.DbOperations;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }

        public GetByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public BookViewModel Handle()
        {
            var book = _dbContext.Books.Where(book => book.Id == BookId).SingleOrDefault();
            if (book is null)
            {
                throw new InvalidOperationException("Kitap Bulunamadı");
            }

            BookViewModel vm = new BookViewModel();
            vm.Title = book.Title;
            vm.PageCount = book.PageCount;
            vm.PublisDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
            vm.Genre = ((GenreEnum)book.GenreId).ToString();
            return vm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }

        public int PageCount { get; set; }

        public string PublisDate { get; set; }

        public string Genre { get; set; }
    }
}
