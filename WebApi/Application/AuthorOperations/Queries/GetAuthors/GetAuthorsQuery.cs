using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOperations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorsQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorsQuery(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAuthorsViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.AuthorId);
            List<GetAuthorsViewModel> returnObj = _mapper.Map<List<GetAuthorsViewModel>>(authors);
            return returnObj;

        }
    }

    public class GetAuthorsViewModel
    {
        public int AuthorId { get; set; }

        public string Name { get; set; }

    

        public DateTime BirthDate { get; set; }
    }
}
