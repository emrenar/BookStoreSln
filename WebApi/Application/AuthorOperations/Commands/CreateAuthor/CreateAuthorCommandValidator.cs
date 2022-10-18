using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
          
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
            RuleFor(x => x.Model.Name).MinimumLength(3);
        }
    }
}
