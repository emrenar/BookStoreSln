using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteCommandAuthorValidator:AbstractValidator<DeleteCommandAuthor>
    {
        public DeleteCommandAuthorValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);

        }
    }
}
