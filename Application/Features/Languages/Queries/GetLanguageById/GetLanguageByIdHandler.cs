using Application.Features.Languages.Rules;
using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Languages.Queries.GetLanguageById
{
    public class GetLanguageByIdHandler : IRequestHandler<GetLanguageByIdRequest, GetLanguageByIdResponse>
    {
        private readonly ILanguageDal LanguageDal;
        private readonly LanguageBusinessRules LanguageBusinessRules;

        public GetLanguageByIdHandler(ILanguageDal languageDal, LanguageBusinessRules languageBusinessRules)
        {
            LanguageDal = languageDal;
            LanguageBusinessRules = languageBusinessRules;
        }

        public async Task<GetLanguageByIdResponse> Handle(GetLanguageByIdRequest request, CancellationToken cancellationToken)
        {
            await LanguageBusinessRules.IsLanguageNameExists(request.Id);

            var result = await LanguageDal.GetAsync(x => x.Id == request.Id);
            return new GetLanguageByIdResponse
            {
                Id = result.Id,
                Name = result.Name
            };
        }
    }
}
