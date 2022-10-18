using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteCommandAuthor
    {
        private readonly BookStoreDbContext _context;
        public int AuthorId { get; set; }
        public DeleteCommandAuthor(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Silmek istediğiniz yazar bulunamadı");
            }
            if (_context.Books.Any(x => x.AuthorId == AuthorId))
            {
                throw new InvalidOperationException("Silmek istediğiniz yazarın yayında kitabı olduğu için silemezsiniz.");
            }
            _context.Remove(author);
            _context.SaveChanges();
        }
    }
}
