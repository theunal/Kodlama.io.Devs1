using Application.Features.Languages.Commands.AddLanguage;
using FluentValidation;

namespace Application.Features.Languages.Commands.UpdateLanguage.Validator
{
    public class AddLanguageCommandValidator : AbstractValidator<AddLanguageCommandRequest>
    {
        public AddLanguageCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
