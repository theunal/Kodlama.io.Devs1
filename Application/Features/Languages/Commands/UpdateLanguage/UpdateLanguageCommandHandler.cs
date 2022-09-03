using Application.Features.Languages.Rules;
using Application.Repositories;
using MediatR;

namespace Application.Features.Languages.Commands.UpdateLanguage
{
    public class UpdateLanguageCommandHandler :
        IRequestHandler<UpdateLanguageCommandRequest, UpdateLanguageCommandResponse>
    {
        private readonly ILanguageDal languageDal;
        private readonly LanguageBusinessRules languageBusinessRules;

        public UpdateLanguageCommandHandler(ILanguageDal languageDal, LanguageBusinessRules languageBusinessRules)
        {
            this.languageDal = languageDal;
            this.languageBusinessRules = languageBusinessRules;
        }

        public async Task<UpdateLanguageCommandResponse> Handle(UpdateLanguageCommandRequest request,
            CancellationToken cancellationToken)
        {
            var result = await languageDal.GetAsync(x => x.Id == request.LanguageId);

            await languageBusinessRules.IsLanguageNameExists(request.LanguageId);

            if (result is not null)
            {
                result.Name = request.Name.Trim();
                await languageDal.UpdateAsync(result);
            }

            return new UpdateLanguageCommandResponse
            {
                Result = "Ürün güncellendi."
            };
        }
    }
}
