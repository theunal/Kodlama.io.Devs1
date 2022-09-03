using Application.Features.Languages.Rules;
using Application.Repositories;
using MediatR;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public class DeleteLanguageCommandHandler :
        IRequestHandler<DeleteLanguageCommandRequest, DeleteLanguageCommandResponse>
    {
        private readonly ILanguageDal languageDal;
        private readonly LanguageBusinessRules languageBusinessRules;

        public DeleteLanguageCommandHandler(ILanguageDal languageDal, LanguageBusinessRules languageBusinessRules)
        {
            this.languageDal = languageDal;
            this.languageBusinessRules = languageBusinessRules;
        }

        public async Task<DeleteLanguageCommandResponse> Handle(DeleteLanguageCommandRequest request,
            CancellationToken cancellationToken)
        {
            await languageBusinessRules.IsLanguageNameExists(request.LanguageId);

            var language = await languageDal.GetAsync(x => x.Id == request.LanguageId);
            if (language is not null) await languageDal.DeleteAsync(language);

            return new DeleteLanguageCommandResponse
            {
                Result = "Ürün Silindi."
            };
        }
    }
}
