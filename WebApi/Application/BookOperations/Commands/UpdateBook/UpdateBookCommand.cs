using WebApi.DbOperations;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommand
    {
        public UpdateBookModel Model { get; set; }

        public int BookId { get; set; }

        private readonly IBookStoreDbContext _dbContext;
        public UpdateBookCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var book = _dbContext.Books.Find(BookId);

            if (book.Id==BookId)
            {
                book.Title = Model.Title != default ? Model.Title : book.Title;
                book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
                book.PageCount = Model.PageCount != default ? Model.PageCount : book.PageCount;
                book.PublishDate = Model.PublishDate != default ? Model.PublishDate : book.PublishDate;
                book.AuthorId = Model.AuthorId != default ? Model.AuthorId : book.AuthorId;
               
                _dbContext.SaveChanges();
            }
            else if (book.Id != BookId)
            {
                throw new InvalidOperationException("Güncellenecek kitap bulunamadı.");
            }
        }
    }
    public class UpdateBookModel
    {
        public string Title { get; set; }

        public int GenreId { get; set; }

        public int PageCount { get; set; }

        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }

    }
}
