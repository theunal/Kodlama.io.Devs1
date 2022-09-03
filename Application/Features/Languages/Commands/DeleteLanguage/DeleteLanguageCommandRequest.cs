using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandRequest : IRequest<DeleteLanguageCommandResponse>
    {
        public int LanguageId { get; set; }
    }
}
