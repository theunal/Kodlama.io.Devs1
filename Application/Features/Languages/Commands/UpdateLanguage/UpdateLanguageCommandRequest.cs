using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandRequest : IRequest<UpdateLanguageCommandResponse>
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
    }
}
