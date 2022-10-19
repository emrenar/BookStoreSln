using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
      

        public int AuthorId { get; set; }
        public AuthorUpdateModel Model { get; set; }
        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Böyle bir yazar bulunamadı");
            }

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.BirthDate = Model.BirthDate != default ? Model.BirthDate : author.BirthDate;
          
            _context.SaveChanges();
        }
    }
    public class AuthorUpdateModel
    {
        public string  Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
