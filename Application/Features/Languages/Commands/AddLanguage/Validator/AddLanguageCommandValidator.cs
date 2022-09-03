using FluentValidation;

namespace Application.Features.Languages.Commands.AddLanguage
{
    public class AddLanguageCommandValidator : AbstractValidator<AddLanguageCommandRequest>
    {
        public AddLanguageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).NotNull();
        }
    }
}
