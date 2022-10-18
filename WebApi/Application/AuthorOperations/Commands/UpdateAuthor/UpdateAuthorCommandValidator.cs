using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator:AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.AuthorId).GreaterThan(0);         
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
            RuleFor(x => x.Model.Name).MinimumLength(4);
        }
    }
}
