using MediatR;

namespace Application.Features.Languages.Commands.AddLanguage
{
    public class AddLanguageCommandRequest : IRequest<AddLanguageCommandResponse>
    {
        public string Name { get; set; }
    }
}
