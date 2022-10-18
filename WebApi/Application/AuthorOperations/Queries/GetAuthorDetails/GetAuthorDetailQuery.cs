using AutoMapper;
using WebApi.DbOperations;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetails
{
    public class GetAuthorDetailQuery
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public int AuthorId { get; set; }

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAuthorDetailViewModel Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.AuthorId == AuthorId);
            if (author is null)
            {
                throw new InvalidOperationException("Yazar bulunamadı");
            }
           
            return _mapper.Map<GetAuthorDetailViewModel>(author);
        }
    }
    public class GetAuthorDetailViewModel
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
