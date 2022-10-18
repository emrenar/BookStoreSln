using FluentValidation;

namespace WebApi.BookOperations.GetBooks
{
    public class GetByIdQueryValidator:AbstractValidator<GetByIdQuery>
    {
        public GetByIdQueryValidator()
        {
            RuleFor(query => query.BookId).GreaterThan(0);
        }
    }
}
