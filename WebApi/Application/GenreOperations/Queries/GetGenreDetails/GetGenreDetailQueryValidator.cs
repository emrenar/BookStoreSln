using FluentValidation;

namespace WebApi.Application.GenreOperations.Queries.GetGenreDetails
{
    public class GetGenreDetailQueryValidator:AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query => query.GenreId).GreaterThan(0);           
        }
    }
}
